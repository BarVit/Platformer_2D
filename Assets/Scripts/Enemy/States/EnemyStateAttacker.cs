using UnityEngine;

public class EnemyStateAttacker : EnemyState
{
    [SerializeField] private AnimationHandler _animationHandler;

    public override void Enter()
    {
        IsComplete = false;
        Animator.Attack();
        _animationHandler.StartAttackAnimation();
    }

    public override void Do()
    {
        if (_animationHandler.IsAttacking == false)
            IsComplete = true;
    }

    public override void Exit()
    {
    }
}