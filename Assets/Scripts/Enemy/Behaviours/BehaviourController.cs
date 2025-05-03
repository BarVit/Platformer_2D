using UnityEngine;

public class BehaviourController : MonoBehaviour
{
    [SerializeField] private TargetFinder _targetFinder;
    [SerializeField] private EnemyPatroller _patroller;
    [SerializeField] private EnemyPursuer _pursuer;
    [SerializeField] private EnemyAttacker _attacker;

    private EnemyBehaviour _enemyBehaviour;

    public Player Target { get; private set; }

    private void OnEnable()
    {
        _targetFinder.Entered += SetTarget;
        _targetFinder.Exited += SetTarget;
    }

    private void OnDisable()
    {
        _targetFinder.Entered -= SetTarget;
        _targetFinder.Exited -= SetTarget;
    }

    private void Start()
    {
        _enemyBehaviour = _patroller;
        _enemyBehaviour.Enter();
    }

    private void Update()
    {
        if (_enemyBehaviour.IsComplete)
            SelectBehaviour();

        _enemyBehaviour.Do();
    }

    private void SelectBehaviour()
    {
        EnemyBehaviour oldBehaviour = _enemyBehaviour;

        if (Target == null)
        {
            _enemyBehaviour = _patroller;
        }
        else if (_enemyBehaviour == _pursuer)
        {
            _enemyBehaviour = _attacker;
        }
        else
        {
            _enemyBehaviour = _pursuer;
            _enemyBehaviour.SetTarget(Target);
        }

        if (_enemyBehaviour != oldBehaviour)
        {
            oldBehaviour.Exit();
            _enemyBehaviour.Enter();
        }
    }

    private void SetTarget(Player target)
    {
        Target = target;
        SelectBehaviour();
    }
}