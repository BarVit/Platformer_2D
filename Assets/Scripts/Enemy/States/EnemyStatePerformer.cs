using UnityEngine;

public class EnemyStateExecutor : MonoBehaviour
{
    //[SerializeField] private AttackStateActivator _attackStateActivator;
    [SerializeField] private PursuitStateActivator _pursuitStateActivator;
    [SerializeField] private PatrolStateActivator _patrolStateActivator;

    private EnemyState _currentState;

    private void OnEnable()
    {
        //_attackStateActivator.Insided += SetState;
        _pursuitStateActivator.Insided += SetState;
        _patrolStateActivator.OutSided += SetState;
    }

    private void OnDisable()
    {
        //_attackStateActivator.Insided -= SetState;
        _pursuitStateActivator.Insided -= SetState;
        _patrolStateActivator.OutSided -= SetState;
    }

    private void Start()
    {
        _currentState = _patrolStateActivator.GetState(null);
    }

    private void Update()
    {
        _currentState.Do();
    }

    private void SetState(Player target, IEnemyStateActivable enemyStateActivator)
    {
        EnemyState newState = enemyStateActivator.GetState(target);

        if (_currentState != newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
    }
}