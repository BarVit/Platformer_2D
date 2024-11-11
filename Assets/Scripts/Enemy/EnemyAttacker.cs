using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyMover), typeof(EnemyAnimator), typeof(Weapon))]
public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _hitRangeX = 1f;
    [SerializeField] private float _hitRate = 1.1f;

    private EnemyMover _enemyMover;
    private EnemyAnimator _enemyAnimator;
    private PlayerHealth _target;
    private float _cooldown = 0;
    private int _direction = 0;
    private bool _isAttacking = false;
    private bool _isAttackEnded = true;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
        _enemyAnimator = GetComponent<EnemyAnimator>();
    }

    private void Update()
    {
        if (_isAttacking && _target != null)
        {
            DefineDirection();
            _enemyMover.SetFaceDirection(_direction);

            if (IsInHitRange() && _isAttackEnded)
                StartCoroutine(Hit());
            else if (_isAttackEnded)
                Approach();
        }
    }

    public void StartAttack(PlayerHealth player)
    { 
        _target = player;
        _isAttacking = true;
    }

    public void StopAttack()
    {
        _target = null;
        _isAttacking = false;
    }

    private bool IsInHitRange()
    {
        return Mathf.Abs(transform.position.x - _target.transform.position.x) < _hitRangeX;
    }

    private void DefineDirection()
    {
        if (transform.position.x > _target.transform.position.x && IsInHitRange() == false)
            _direction = -1;
        else if (transform.position.x < _target.transform.position.x && IsInHitRange() == false)
            _direction = 1;
        else
            _direction = 0;
    }

    private IEnumerator Hit()
    {
        _enemyMover.Stop();
        _enemyAnimator.SetSpeed(0);
        _enemyAnimator.Attack();
        _isAttackEnded = false;
        _cooldown = _hitRate;

        while (_cooldown > 0)
        {
            _cooldown -= Time.deltaTime;
            
            yield return null;
        }

        _isAttackEnded = true;
    }

    private void Approach()
    {
        _enemyMover.Move(_direction);

        if (_direction == 0)
            _enemyAnimator.SetSpeed(0);
        else
            _enemyAnimator.SetSpeed(_enemyMover.Speed);
    }
}