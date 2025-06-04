using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public EnemyAttacker Attacker;
    public EnemyPursuer Pursuer;
    public EnemyPatroller Patroller;
    public TargetFinder TargetFinder;
    public EnemyAnimator Animator;
    public AnimationHandler AnimationHandler;
    public FaceDirectioneer SpriteDirection;
    public EnemyMover Mover;
    public Transform[] Waypoints;

    private EnemyState _currentState;
    private bool _isRunning;

    private void Awake()
    {
        Attacker = new EnemyAttacker(this);
        Pursuer = new EnemyPursuer(this);
        Patroller = new EnemyPatroller(this, Waypoints);
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

    public void Run()
    {
        _currentState = Patroller;
        _currentState.Enter();
        _isRunning = true;
    }

    public void Stop()
    {
        _currentState.Exit();
        _isRunning = false;
    }
}