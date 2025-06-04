using UnityEngine;

public class EnemyPursuer : EnemyState
{
    private float _hitRangeX = 1f;

    private int _direction = 0;
    private int _leftDirection = -1;
    private int _rightDirection = 1;

    public EnemyPursuer(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override EnemyState RunState()
    {
        if (StateMachine.TargetFinder.Target == null || StateMachine.TargetFinder.Target.IsAlive == false)
        {
            return StateMachine.Patroller;
        }
        else if (IsTargetInHitRange() && IsTargetInFront())
        {
            StateMachine.Mover.Stop();
            StateMachine.Animator.SetSpeed(0);
            return StateMachine.Attacker;
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
        StateMachine.SpriteDirection.SetFaceDirection(_direction);
        StateMachine.Mover.Move(_direction);
        StateMachine.Animator.SetSpeed(StateMachine.Mover.Speed);
    }

    private void DefineDirection()
    {
        if (StateMachine.transform.position.x > StateMachine.TargetFinder.Target?.transform.position.x)
            _direction = _leftDirection;
        else if (StateMachine.transform.position.x < StateMachine.TargetFinder.Target?.transform.position.x)
            _direction = _rightDirection;
    }

    private bool IsTargetInHitRange()
    {
        return Mathf.Abs(StateMachine.transform.position.x - StateMachine.TargetFinder.Target.transform.position.x) < _hitRangeX;
    }

    private bool IsTargetInFront()
    {
        if (_direction == _rightDirection)
            return StateMachine.transform.position.x < StateMachine.TargetFinder.Target?.transform.position.x;
        else
            return StateMachine.transform.position.x > StateMachine.TargetFinder.Target?.transform.position.x;
    }
}