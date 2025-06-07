using UnityEngine;

[RequireComponent(typeof(TargetFinder))]
public class StateMachine : MonoBehaviour
{
    [SerializeField] private Transform[] Waypoints;

    [System.NonSerialized] public TargetFinder TargetFinder;

    public EnemyAttacker Attacker;
    public EnemyPursuer Pursuer;
    public EnemyPatroller Patroller;
    public EnemyAnimator Animator;
    public AttackAnimationHandler AnimationHandler;
    public FaceDirectioneer SpriteDirection;
    public EnemyMover Mover;

    private EnemyState _currentState;
    private bool _isRunning;

    private void Awake()
    {
        Attacker = new EnemyAttacker(this);
        Pursuer = new EnemyPursuer(this);
        Patroller = new EnemyPatroller(this, Waypoints);
        TargetFinder = GetComponent<TargetFinder>();
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