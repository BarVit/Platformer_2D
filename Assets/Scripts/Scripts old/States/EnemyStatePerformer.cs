using UnityEngine;

public class EnemyStateExecutor : MonoBehaviour
{
    [SerializeField] private AttackStateActivator _attackStateActivator;
    [SerializeField] private PursuitStateActivator _pursuitStateActivator;
    [SerializeField] private PatrolStateActivator _patrolStateActivator;

    private EnemyState2 _currentState;
    private EnemyState2 _newState;

    private void OnEnable()
    {
        _attackStateActivator.AttackRanged += SetState;
        _pursuitStateActivator.Insided += SetState;
        _patrolStateActivator.OutSided += SetState;
    }

    private void OnDisable()
    {
        _attackStateActivator.AttackRanged -= SetState;
        _pursuitStateActivator.Insided -= SetState;
        _patrolStateActivator.OutSided -= SetState;
    }

    private void Start()
    {
        _currentState = _patrolStateActivator.GetState();
    }

    private void Update()
    {
        SelectState();
        _currentState.Do();
    }

    private void SetState(Player target, EnemyStateActivator enemyStateActivator)
    {
        _newState = enemyStateActivator.GetState();

        if (_newState != _currentState && _currentState.IsBlocked == false)
        {
            _currentState.Exit();
            _currentState = _newState;

            if (target != null)
                _currentState.Enter(target);
            else
                _currentState.Enter();
        }
    }

    private void SelectState()
    {

    }
}