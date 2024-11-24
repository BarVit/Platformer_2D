using UnityEngine;

[RequireComponent(typeof(EnemyPatroller), typeof(EnemyAttacker))]
public class BehaviourController : MonoBehaviour
{
    [SerializeField] private TargetFinder _targetFinder;

    private EnemyPatroller _patroller;
    private EnemyAttacker _enemyAttacker;

    private void Awake()
    {
        _patroller = GetComponent<EnemyPatroller>();
        _enemyAttacker = GetComponent<EnemyAttacker>();
    }

    private void OnEnable()
    {
        _targetFinder.Entered += SetAttackBehaviour;
        _targetFinder.Exited += SetPatrolBehaviour;
    }

    private void OnDisable()
    {
        _targetFinder.Entered -= SetAttackBehaviour;
        _targetFinder.Exited -= SetPatrolBehaviour;
    }

    private void Start()
    {
        _enemyAttacker.StopAttack();
        _patroller.StartPatrol();
    }

    public void SetAttackBehaviour(Player player)
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