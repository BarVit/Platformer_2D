using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMover), typeof(EnemyAnimator))]
public class EnemyPatroller : MonoBehaviour
{
    [SerializeField] private Transform[] _waypointsTransforms;

    private EnemyMover _enemyMover;
    private EnemyAnimator _enemyAnimator;
    private Coroutine _waiterAtWaypoint;
    private Vector3[] _waypoints;
    private Vector3 _waypoint;
    private float _waitAtWaypointTime = 2f;
    private int _index = 0;
    private int _direction = 0;
    private bool _isWaiting = false;
    private bool _isPatrolling = true;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
        _enemyAnimator = GetComponent<EnemyAnimator>();
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
            _enemyMover.SetFaceDirection(_direction);
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
        if (_isWaiting)
            _direction = 0;
        else if (transform.position.x <= _waypoint.x && _direction == -1)
            _direction = 0;
        else if (transform.position.x >= _waypoint.x && _direction == 1)
            _direction = 0;
        else
        {
            if (transform.position.x < _waypoint.x)
                _direction = 1;
            else if (transform.position.x > _waypoint.x)
                _direction = -1;
        }
    }

    private void SetAnimation()
    {
        if (_direction == 0)
            _enemyAnimator.SetSpeed(0);
        else
            _enemyAnimator.SetSpeed(_enemyMover.Speed);
    }

    private void Patrol()
    {
        if (_direction == 0 && _isWaiting == false)
        {
            _isWaiting = true;
            _enemyMover.Stop();
            _waiterAtWaypoint = StartCoroutine(WaitAtWaypoint());
        }
        else
        {
            _enemyMover.Move(_direction);
        }
    }

    private IEnumerator WaitAtWaypoint()
    {
        float randomMultiplayer = Random.Range(0.5f, 2f);
        float waitingTime = _waitAtWaypointTime * randomMultiplayer;

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