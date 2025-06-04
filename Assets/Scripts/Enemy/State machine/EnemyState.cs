public abstract class EnemyState
{
    protected StateMachine StateMachine;

    public EnemyState(StateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    public abstract EnemyState RunState();

    public virtual void Enter() { }
    public virtual void Exit() { }
}