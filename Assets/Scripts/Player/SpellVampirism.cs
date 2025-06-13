using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyFinder), typeof(SpriteRenderer))]
public class SpellVampirism : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private Health _player;
    [SerializeField] private float _damagePerSec = 10f;

    private EnemyFinder _enemyFinder;
    private SpriteRenderer _spriteRenderer;
    private bool _isWaiting = false;

    public event Action SpellStarted;
    public event Action SpellEnded;
    public event Action CooldownStarted;
    public event Action CooldownEnded;
    public event Action<float, float> TimeChanged;

    [field : SerializeField] public float Duration { get; private set; }
    [field : SerializeField] public float Cooldown { get; private set; }

    private void Awake()
    {
        _enemyFinder = GetComponent<EnemyFinder>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Duration = 6f;
        Cooldown = 4f;
    }

    public void Cast()
    {
        if (_isWaiting == false)
        {
            _isWaiting = true;
            SpellStarted?.Invoke();
            _spriteRenderer.enabled = true;
            _animator.CastSpell(true);
            StartCoroutine(CastSpell());
        }
    }

    private IEnumerator CastSpell()
    {
        Health target ;
        float castTime = Duration;
        float damage = 0;
        int minDamage = 1;

        while (castTime > 0)
        {
            castTime -= Time.deltaTime;
            TimeChanged?.Invoke(castTime, Duration);
            target = _enemyFinder.GetTarget();

            if(target != null)
            {
                damage += _damagePerSec * Time.deltaTime;

                if (damage > minDamage)
                {
                    target.TakeDamage((int)damage);
                    _player.Heal((int)damage);
                }

                damage -= (int)damage;
            }

            yield return null;
        }

        SpellEnded?.Invoke();
        _animator.CastSpell(false);
        _spriteRenderer.enabled = false;
        CooldownStarted?.Invoke();
        StartCoroutine(WaitCooldown());
    }

    private IEnumerator WaitCooldown()
    {
        float cooldownTime = Cooldown;

        while(cooldownTime > 0)
        {
            cooldownTime -= Time.deltaTime;
            TimeChanged?.Invoke(Cooldown - cooldownTime, Cooldown);

            yield return null;
        }

        CooldownEnded?.Invoke();
        _isWaiting = false;
    }
}