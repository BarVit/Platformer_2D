using UnityEngine;

[RequireComponent(typeof(EnemyPatroller), typeof(EnemyAttacker))]
public class BehaviourController : MonoBehaviour
{
    [SerializeField] private TargetFinder targetFinder;

    private EnemyPatroller _patroller;
    private EnemyAttacker _enemyAttacker;

    private void Awake()
    {
        _patroller = GetComponent<EnemyPatroller>();
        _enemyAttacker = GetComponent<EnemyAttacker>();
    }

    private void Start()
    {
        _enemyAttacker.StopAttack();
        _patroller.StartPatrol();
    }

    public void SetAttackBehaviour(PlayerHealth player)
    {
        _enemyAttacker.StartAttack(player);
        _patroller.StopPatrol();
    }

    public void SetPatrolBehaviour()
    {
        _enemyAttacker.StopAttack();
        _patroller.StartPatrol();
    }
}