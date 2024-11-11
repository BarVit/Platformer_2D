using UnityEngine;

[RequireComponent(typeof(FaceDirectioneer), typeof(PlayerAnimator), typeof(InputHandler))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private GroundSensor _groundSensor;
    [SerializeField] private float _jumpForce = 7.5f;

    private FaceDirectioneer _faceDirectioneer;
    private PlayerAnimator _playerAnimator;
    private InputHandler _inputHandler;
    private Rigidbody2D _rigidbody2D;
    private int _direction = 0;

    public float Speed { get; private set; }
    public bool Grounded { get; private set; }

    private void Awake()
    {
        _faceDirectioneer = GetComponent<FaceDirectioneer>();
        _playerAnimator = GetComponent<PlayerAnimator>();
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
            _playerAnimator.Jump();
        }
    }

    private void DefineStartOrEndOfJump()
    {
        if (_groundSensor.IsGrounded == false && Grounded)
        {
            Grounded = false;
            _playerAnimator.ChangeGroundedBool(Grounded);
        }
        else if (_groundSensor.IsGrounded && Grounded == false)
        {
            Grounded = true;
            _playerAnimator.ChangeGroundedBool(Grounded);
        }
    }

    private void DefineDirection()
    {
        if (_inputHandler.InputX > 0)
            _direction = 1;
        else if (_inputHandler.InputX < 0)
            _direction = -1;
    }

    private void SetFaceDirection()
    {
        _faceDirectioneer.SetFaceDirection(transform, _direction);
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(_inputHandler.InputX * Speed, _rigidbody2D.velocity.y);
    }
}