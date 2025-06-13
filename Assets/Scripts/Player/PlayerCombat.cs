using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private SpellVampirism _spellVampirism;

    public bool IsCasting { get; private set; }

    private void OnEnable()
    {
        _spellVampirism.SpellStarted += OnSpellStarted;
        _spellVampirism.SpellEnded += OnSpellEnded;
    }

    private void OnDisable()
    {
        _spellVampirism.SpellStarted -= OnSpellStarted;
        _spellVampirism.SpellEnded -= OnSpellEnded;
    }

    public void Attack()
    {
        _animator.Attack();
    }

    public void CastSpell()
    {
        _spellVampirism.Cast();
    }

    private void OnSpellStarted()
    {
        IsCasting = true;
    }

    private void OnSpellEnded()
    {
        IsCasting = false;
    }
}