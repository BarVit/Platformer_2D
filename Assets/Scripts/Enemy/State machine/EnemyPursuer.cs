using UnityEngine;

public class EnemyPursuer : EnemyState
{
    [SerializeField] private EnemyAttacker _attacker;
    [SerializeField] private EnemyPatroller _patroller;
    [SerializeField] private float _hitRangeX = 1f;

    private int _direction = 0;
    private int _leftDirection = -1;
    private int _rightDirection = 1;

    public override EnemyState RunState()
    {
        if (TargetFinder.Target == null)
        {
            return _patroller;
        }
        else if (IsTargetInHitRange() && IsTargetInFront())
        {
            Mover.Stop();
            Animator.SetSpeed(0);
            return _attacker;
        }
        else
        {
            Approach();
            return this;
        }
    }

    private void Approach()
    {
        DefineDirection();
        SpriteDirection.SetFaceDirection(_direction);
        Mover.Move(_direction);
        Animator.SetSpeed(Mover.Speed);
    }

    private void DefineDirection()
    {
        if (transform.position.x > TargetFinder.Target?.transform.position.x)
            _direction = _leftDirection;
        else if (transform.position.x < TargetFinder.Target?.transform.position.x)
            _direction = _rightDirection;
    }

    private bool IsTargetInHitRange()
    {
        return Mathf.Abs(transform.position.x - TargetFinder.Target.transform.position.x) < _hitRangeX;
    }

    private bool IsTargetInFront()
    {
        if (_direction == _rightDirection)
            return transform.position.x < TargetFinder.Target?.transform.position.x;
        else
            return transform.position.x > TargetFinder.Target?.transform.position.x;
    }
}