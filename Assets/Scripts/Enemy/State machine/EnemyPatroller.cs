using System.Collections;
using UnityEngine;

public class EnemyPatroller : EnemyState
{
    private Transform[] _waypointsTransforms;
    private Coroutine _waiterAtWaypoint;
    private Vector3[] _waypoints;
    private Vector3 _waypoint;
    private float _waitAtWaypointTime = 2f;
    private int _index = 0;
    private int _direction = 0;
    private int _nonDirection = 0;
    private bool _isWaiting = false;

    public EnemyPatroller(EnemyStateMachine stateMachine, Transform[] waypoints) : base(stateMachine)
    {
        _waypointsTransforms = waypoints;
        Awake();
    }

    private void Awake()
    {
        _waypoints = new Vector3[_waypointsTransforms.Length];

        for (int i = 0; i < _waypointsTransforms.Length; i++)
            _waypoints[i] = _waypointsTransforms[i].position;

        _waypoint = _waypoints[_index];
    }

    public override void Enter()
    {
        _isWaiting = true;
        _waiterAtWaypoint = Coroutines.StartRoutine(WaitAtWaypoint());
    }

    public override EnemyState RunState()
    {
        DefineDirection();
        StateMachine.Enemy.SpriteDirection.SetFaceDirection(_direction);
        SetAnimation();
        Patrol();

        if (StateMachine.Enemy.TargetFinder.Target == null)
            return this;
        else
            return StateMachine.Pursuer;
    }

    public override void Exit()
    {
        StateMachine.Enemy.Mover.Stop();
        if (_waiterAtWaypoint != null)
            Coroutines.StopRoutine(_waiterAtWaypoint);
    }

    private void DefineDirection()
    {
        int leftDirection = -1;
        int rightDirection = 1;

        if (_isWaiting)
            _direction = _nonDirection;
        else if (StateMachine.transform.position.x <= _waypoint.x && _direction == leftDirection)
            _direction = _nonDirection;
        else if (StateMachine.transform.position.x >= _waypoint.x && _direction == rightDirection)
            _direction = _nonDirection;
        else
        {
            if (StateMachine.transform.position.x < _waypoint.x)
                _direction = rightDirection;
            else if (StateMachine.transform.position.x > _waypoint.x)
                _direction = leftDirection;
        }
    }

    private void SetAnimation()
    {
        if (_direction == _nonDirection)
            StateMachine.Enemy.Animator.SetSpeed(0);
        else
            StateMachine.Enemy.Animator.SetSpeed(StateMachine.Enemy.Mover.Speed);
    }

    private void Patrol()
    {
        if (_direction == _nonDirection && _isWaiting == false)
        {
            StateMachine.Enemy.Mover.Stop();
            _isWaiting = true;
            _waiterAtWaypoint = Coroutines.StartRoutine(WaitAtWaypoint());
        }
        else
        {
            StateMachine.Enemy.Mover.Move(_direction);
        }
    }

    private IEnumerator WaitAtWaypoint()
    {
        float minTimeMultiplier = 0.5f;
        float maxTimeMultiplier = 2f;
        float waitingTime = _waitAtWaypointTime * Random.Range(minTimeMultiplier, maxTimeMultiplier);

        while (waitingTime > 0)
        {
            waitingTime -= Time.deltaTime;

            yield return null;
        }

        _isWaiting = false;
        _waypoint = GetNextWaypoint();
    }

    private Vector3 GetNextWaypoint()
    {
        _index = ++_index % _waypoints.Length;
        return _waypoints[_index];
    }
}