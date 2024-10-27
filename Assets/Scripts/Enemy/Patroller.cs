using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(EnemyAnimator))]
public class Patroller : MonoBehaviour
{
    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private Transform[] _waypointsTransforms;

    private EnemyAnimator _enemyAnimatorLogic;
    private Rigidbody2D _rigidbody2D;
    private Vector3[] _waypoints;
    private Vector3 _waypoint;
    private Vector3 _rightDirection = new Vector3(0, 180, 0);
    private Vector3 _leftDirection = new Vector3(0, 0, 0);
    private float _stayAtWaypointTime = 2f;
    private int _index = 0;
    private int _direction = 0;
    private bool _isRunning = true;

    private void Awake()
    {
        _enemyAnimatorLogic = GetComponent<EnemyAnimator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _waypoints = new Vector3[_waypointsTransforms.Length];

        for (int i = 0; i < _waypointsTransforms.Length; i++)
            _waypoints[i] = _waypointsTransforms[i].position;

        _waypoint = _waypoints[_index];
    }

    private void Update()
    {
        SetFaceDirection();
        Patrol();
        SetAnimation();
    }

    private void SetFaceDirection()
    {
        if (_direction == 1)
            transform.rotation = Quaternion.Euler(_rightDirection);
        else if (_direction == -1)
            transform.rotation = Quaternion.Euler(_leftDirection);
    }

    private void SetAnimation()
    {
        if (_direction == 0)
            _enemyAnimatorLogic.SetSpeed(0);
        else
            _enemyAnimatorLogic.SetSpeed(_speed);
    }

    private void Patrol()
    {
        if (transform.position.x >= _waypoint.x && _direction == 1)
            _direction = 0;
        else if (transform.position.x <= _waypoint.x && _direction == -1)
            _direction = 0;
        else if (transform.position.x < _waypoint.x && _isRunning)
            _direction = 1;
        else if (transform.position.x > _waypoint.x && _isRunning)
            _direction = -1;

        if (_direction == 0 && _isRunning)
        {
            _isRunning = false;
            StartCoroutine(StayAtWaypoint());
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(_direction * _speed, _rigidbody2D.velocity.y);
        }
    }

    private IEnumerator StayAtWaypoint()
    {
        float randomMultiplayer = Random.Range(0.5f, 2f);
        float stayingTime = _stayAtWaypointTime * randomMultiplayer;

        while (stayingTime > 0)
        {
            stayingTime -= Time.deltaTime;

            yield return null;
        }

        _waypoint = GetNextWaypoint();
        _isRunning = true;
    }

    private Vector3 GetNextWaypoint()
    {
        _index = ++_index % _waypoints.Length;
        return _waypoints[_index];
    }
}