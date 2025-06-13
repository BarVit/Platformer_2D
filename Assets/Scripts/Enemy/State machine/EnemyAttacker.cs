public class EnemyAttacker : EnemyState
{
    public EnemyAttacker(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        StateMachine.Animator.Attack();
        StateMachine.AnimationHandler.StartAttackAnimation();
    }

    public override EnemyState RunState()
    {
        if(StateMachine.TargetFinder.Target != null)
        {
            if (StateMachine.AnimationHandler.IsAttacking && StateMachine.TargetFinder.Target.Value > 0)
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