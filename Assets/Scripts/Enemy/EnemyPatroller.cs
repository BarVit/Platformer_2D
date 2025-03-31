using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class EnemyPatroller : MonoBehaviour
{
    [SerializeField] private Transform[] _waypointsTransforms;
    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private FaceDirectioneer _spriteDirection;

    private EnemyMover _mover;
    private Coroutine _waiterAtWaypoint;
    private Vector3[] _waypoints;
    private Vector3 _waypoint;
    private float _waitAtWaypointTime = 2f;
    private int _index = 0;
    private int _direction = 0;
    private int _nonDirection = 0;
    private bool _isWaiting = false;
    private bool _isPatrolling = true;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _waypoints = new Vector3[_waypointsTransforms.Length];

        for (int i = 0; i < _waypointsTransforms.Length; i++)
            _waypoints[i] = _waypointsTransforms[i].position;

        _waypoint = _waypoints[_index];
    }

    private void Update()
    {
        if (_isPatrolling)
        {
            DefineDirection();
            SetAnimation();
            _spriteDirection.SetFaceDirection(_direction);
            Patrol();
        }
    }

    public void StartPatrol()
    {
        _isPatrolling = true;
        _isWaiting = true;
        _waiterAtWaypoint = StartCoroutine(WaitAtWaypoint());
    }

    public void StopPatrol()
    {
        _isPatrolling = false;
        StopCoroutine(_waiterAtWaypoint);
    }

    private void DefineDirection()
    {
        int leftDirection = -1;
        int rightDirection = 1;

        if (_isWaiting)
            _direction = _nonDirection;
        else if (transform.position.x <= _waypoint.x && _direction == leftDirection)
            _direction = _nonDirection;
        else if (transform.position.x >= _waypoint.x && _direction == rightDirection)
            _direction = _nonDirection;
        else
        {
            if (transform.position.x < _waypoint.x)
                _direction = rightDirection;
            else if (transform.position.x > _waypoint.x)
                _direction = leftDirection;
        }
    }

    private void SetAnimation()
    {
        if (_direction == _nonDirection)
            _animator.SetSpeed(0);
        else
            _animator.SetSpeed(_mover.Speed);
    }

    private void Patrol()
    {
        if (_direction == _nonDirection && _isWaiting == false)
        {
            _isWaiting = true;
            _mover.Stop();
            _waiterAtWaypoint = StartCoroutine(WaitAtWaypoint());
        }
        else
        {
            _mover.Move(_direction);
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