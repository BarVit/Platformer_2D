using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(InputHandler), typeof(PlayerAnimator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private GroundSensor _groundSensor;
    [SerializeField] private float _jumpForce = 7.5f;

    private PlayerAnimator _animatorLogic;
    private InputHandler _inputHandler;
    private Rigidbody2D _rigidbody2D;
    private Vector3 _rightDirection = new Vector3(0, 0, 0);
    private Vector3 _leftDirection = new Vector3(0, 180, 0);

    public float Speed { get; private set; }
    public bool Grounded { get; private set; }

    private void Awake()
    {
        _animatorLogic = GetComponent<PlayerAnimator>();
        _inputHandler = GetComponent<InputHandler>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Speed = 4f;
    }

    private void Update()
    {
        DefineStartOrEndOfJump();
        SetFaceDirection();
        _rigidbody2D.velocity = new Vector2(_inputHandler.InputX * Speed, _rigidbody2D.velocity.y);
    }

    public void Jump()
    {
        if (Grounded)
        {
            Grounded = false;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
            _animatorLogic.Jump();
        }
    }

    private void DefineStartOrEndOfJump()
    {
        if (_groundSensor.IsGrounded == false && Grounded)
        {
            Grounded = false;
            _animatorLogic.ChangeGroundedBool(Grounded);
        }
        else if (_groundSensor.IsGrounded && Grounded == false)
        {
            Grounded = true;
            _animatorLogic.ChangeGroundedBool(Grounded);
        }
    }

    private void SetFaceDirection()
    {
        if (_inputHandler.InputX > 0)
            transform.rotation = Quaternion.Euler(_rightDirection);
        else if (_inputHandler.InputX < 0)
            transform.rotation = Quaternion.Euler(_leftDirection);
    }
}