using UnityEngine;

public class EnemyAttacker : EnemyState
{
    [SerializeField] private EnemyPatroller _patroller;
    [SerializeField] private EnemyPursuer _pursuer;
    [SerializeField] private AnimationHandler _animationHandler;

    public override void Enter()
    {
        Animator.Attack();
        _animationHandler.StartAttackAnimation();
    }

    public override EnemyState RunState()
    {
        if (_animationHandler.IsAttacking)
            return this;
        else if (TargetFinder.Target != null)
            return _pursuer;
        else
            return _patroller;
    }
}