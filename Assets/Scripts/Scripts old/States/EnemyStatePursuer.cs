using System;
using UnityEngine;

public class EnemyStatePursuer : EnemyState2
{
    [SerializeField] private float _hitRangeX = 1f;

    public event Action<Player> EnteredAttackArea;

    private int _direction = 0;
    private int _leftDirection = -1;
    private int _rightDirection = 1;

    public override void Enter(Player target)
    {
        Target = target;
    }

    public override void Do()
    {
        if(Target != null)
        {
            if (IsTargetInHitRange() && IsTargetInFront())
            {
                EnteredAttackArea?.Invoke(Target);
                return;
            }

            DefineDirection();
            SpriteDirection.SetFaceDirection(_direction);
            Mover.Move(_direction);
            Animator.SetSpeed(Mover.Speed);
        }
    }

    public override void Exit()
    {
        Target = null;
        Mover.Stop();
        Animator.SetSpeed(0);
    }

    private void DefineDirection()
    {
        if (transform.position.x > Target.transform.position.x)
            _direction = _leftDirection;
        else if (transform.position.x < Target.transform.position.x)
            _direction = _rightDirection;
    }

    private bool IsTargetInHitRange()
    {
        return Mathf.Abs(transform.position.x - Target.transform.position.x) < _hitRangeX;
    }

    private bool IsTargetInFront()
    {
        if (_direction == _rightDirection)
            return transform.position.x < Target.transform.position.x;
        else
            return transform.position.x > Target.transform.position.x;
    }
}