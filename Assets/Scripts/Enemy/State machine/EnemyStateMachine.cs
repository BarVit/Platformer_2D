using UnityEngine;

[RequireComponent(typeof(TargetFinder))]
public class EnemyStateMachine : MonoBehaviour
{
    private EnemyState _currentState;
    private bool _isRunning;

    public Enemy Enemy { get; private set; }
    public EnemyAttacker Attacker { get; private set; }
    public EnemyPursuer Pursuer { get; private set; }
    public EnemyPatroller Patroller { get; private set; }

    private void Awake()
    {
        Attacker = new EnemyAttacker(this);
        Pursuer = new EnemyPursuer(this);
        Patroller = new EnemyPatroller(this, Enemy.Waypoints);
    }

    private void Update()
    {
        if(_isRunning)
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

    public void Activate(Enemy enemy)
    {
        Enemy = enemy;
        _currentState = Patroller;
        _currentState.Enter();
        _isRunning = true;
    }

    public void Stop()
    {
        _currentState.Exit();
        Enemy.Mover.Stop();
        _isRunning = false;
    }
}