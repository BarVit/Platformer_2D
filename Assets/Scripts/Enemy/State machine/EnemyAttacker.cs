public class EnemyAttacker : EnemyState
{
    public EnemyAttacker(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        StateMachine.Enemy.Animator.Attack();
        StateMachine.Enemy.AnimationHandler.StartAttackAnimation();
    }

    public override EnemyState RunState()
    {
        if(StateMachine.Enemy.TargetFinder.Target != null)
        {
            if (StateMachine.Enemy.AnimationHandler.IsAttacking && StateMachine.Enemy.TargetFinder.Target.Value > 0)
                return this;
            else
                return StateMachine.Pursuer;
        }
        else
        {
            return StateMachine.Patroller;
        }
    }
}