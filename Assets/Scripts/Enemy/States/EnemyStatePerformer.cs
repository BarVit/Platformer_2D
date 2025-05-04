using UnityEngine;

public class EnemyStatePerformer : MonoBehaviour
{
    [SerializeField] private TargetFinder _targetFinder;
    [SerializeField] private EnemyStatePatroller _patroller;
    [SerializeField] private EnemyStatePursuer _pursuer;
    [SerializeField] private EnemyStateAttacker _attacker;

    private Player Target;
    private EnemyState _currentState;

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
        _currentState = _patroller;
        _currentState.Enter();
    }

    private void Update()
    {
        if (_currentState.IsComplete)
            SelectState();

        _currentState.Do();
    }

    private void SelectState()
    {
        EnemyState oldState = _currentState;

        if (Target == null)
        {
            _currentState = _patroller;
        }
        else if (_currentState == _pursuer)
        {
            _currentState = _attacker;
        }
        else
        {
            _currentState = _pursuer;
            _currentState.SetTarget(Target);
        }

        if (_currentState != oldState)
        {
            oldState.Exit();
            _currentState.Enter();
        }
    }

    private void SetTarget(Player target)
    {
        Target = target;
        SelectState();
    }
}