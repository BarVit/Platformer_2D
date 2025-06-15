using UnityEngine;

public class EnemyPursuer : EnemyState
{
    private float _hitRangeX = 1f;

    private int _direction = 0;
    private int _leftDirection = -1;
    private int _rightDirection = 1;

    public EnemyPursuer(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override EnemyState RunState()
    {
        if (StateMachine.Enemy.TargetFinder.Target == null || StateMachine.Enemy.TargetFinder.Target.Value == 0)
        {
            return StateMachine.Patroller;
        }
        else if (IsTargetInHitRange() && IsTargetInFront())
        {
            StateMachine.Enemy.Mover.Stop();
            StateMachine.Enemy.Animator.SetSpeed(0);
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
        StateMachine.Enemy.SpriteDirection.SetFaceDirection(_direction);
        StateMachine.Enemy.Mover.Move(_direction);
        StateMachine.Enemy.Animator.SetSpeed(StateMachine.Enemy.Mover.Speed);
    }

    private void DefineDirection()
    {
        if (StateMachine.transform.position.x > StateMachine.Enemy.TargetFinder.Target.transform.position.x)
            _direction = _leftDirection;
        else if (StateMachine.transform.position.x < StateMachine.Enemy.TargetFinder.Target.transform.position.x)
            _direction = _rightDirection;
    }

    private bool IsTargetInHitRange()
    {
        return Mathf.Abs(StateMachine.transform.position.x - StateMachine.Enemy.TargetFinder.Target.transform.position.x) < _hitRangeX;
    }

    private bool IsTargetInFront()
    {
        if (_direction == _rightDirection)
            return StateMachine.transform.position.x < StateMachine.Enemy.TargetFinder.Target.transform.position.x;
        else
            return StateMachine.transform.position.x > StateMachine.Enemy.TargetFinder.Target.transform.position.x;
    }
}