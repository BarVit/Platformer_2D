using UnityEngine;

[RequireComponent(typeof(InputHandler), typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private GroundSensor _groundSensor;
    [SerializeField] private FaceDirectioneer _faceDirectioneer;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private float _jumpForce = 7.5f;

    private InputHandler _inputHandler;
    private Rigidbody2D _rigidbody2D;
    private int _direction = 0;

    public float Speed { get; private set; }
    public bool Grounded { get; private set; }

    private void Awake()
    {
        _inputHandler = GetComponent<InputHandler>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Speed = 4f;
    }

    private void Update()
    {
        DefineStartOrEndOfJump();
        DefineDirection();
        SetFaceDirection();
        Move();
    }

    public void Jump()
    {
        if (Grounded)
        {
            Grounded = false;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
            _animator.Jump();
        }
    }

    private void DefineStartOrEndOfJump()
    {
        if (_groundSensor.IsGrounded == false && Grounded)
        {
            Grounded = false;
            _animator.ChangeGroundedBool(Grounded);
        }
        else if (_groundSensor.IsGrounded && Grounded == false)
        {
            Grounded = true;
            _animator.ChangeGroundedBool(Grounded);
        }
    }

    private void DefineDirection()
    {
        int leftDirection = -1;
        int rightDirection = 1;

        if (_inputHandler.InputX > 0)
            _direction = rightDirection;
        else if (_inputHandler.InputX < 0)
            _direction = leftDirection;
    }

    private void SetFaceDirection()
    {
        _faceDirectioneer.SetFaceDirection(_direction);
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(_inputHandler.InputX * Speed, _rigidbody2D.velocity.y);
    }
}