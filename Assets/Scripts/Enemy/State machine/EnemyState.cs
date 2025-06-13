public abstract class EnemyState
{
    protected EnemyStateMachine StateMachine;

    public EnemyState(EnemyStateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    public abstract EnemyState RunState();

    public virtual void Enter() { }
    public virtual void Exit() { }
}