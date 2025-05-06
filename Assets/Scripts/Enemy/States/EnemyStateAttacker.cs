public class EnemyStateAttacker : EnemyState
{
    public override void Enter()
    {
        Animator.Attack();
    }
}