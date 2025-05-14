using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private EnemyPatroller _patroller;

    private EnemyState _currentState;

    private void Awake()
    {
        _currentState = _patroller;
        _currentState.Enter();
    }

    private void Update()
    {
        EnemyState nextState = _currentState.RunState();

        if (_currentState != nextState)
        {
            _currentState.Exit();
            nextState.Enter();
        }

        _currentState = nextState;
    }
}