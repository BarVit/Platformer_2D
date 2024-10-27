using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(InputHandler))]
[RequireComponent(typeof(AnimatorLogic))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private GroundSensor _groundSensor;
    [SerializeField] private float _jumpForce = 7.5f;

    private AnimatorLogic _animatorLogic;
    private InputHandler _inputHandler;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    public float Speed { get; private set; }
    public bool Grounded { get; private set; }

    private void Awake()
    {
        _animatorLogic = GetComponent<AnimatorLogic>();
        _inputHandler = GetComponent<InputHandler>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
            _spriteRenderer.flipX = false;
        else if (_inputHandler.InputX < 0)
            _spriteRenderer.flipX = true;
    }
}