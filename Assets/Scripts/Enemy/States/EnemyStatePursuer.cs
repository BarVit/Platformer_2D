public class EnemyStatePursuer : EnemyState
{
    private Player _target;
    private int _direction = 0;
    private int _leftDirection = -1;
    private int _rightDirection = 1;

    public override void Do()
    {
        if(_target != null)
        {
            DefineDirection();
            SpriteDirection.SetFaceDirection(_direction);
            Mover.Move(_direction);
            Animator.SetSpeed(Mover.Speed);
        }
    }

    public override void Exit()
    {
        _target = null;
        Mover.Stop();
        Animator.SetSpeed(0);
    }

    public override void SetTarget(Player target)
    {
        _target = target;
    }

    private void DefineDirection()
    {
        if (transform.position.x > _target.transform.position.x)
            _direction = _leftDirection;
        else if (transform.position.x < _target.transform.position.x)
            _direction = _rightDirection;
    }
}