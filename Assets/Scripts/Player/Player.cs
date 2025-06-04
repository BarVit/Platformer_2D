using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(PlayerCombat), typeof(InputHandler))]
[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private FaceDirectioneer _faceDirectioneer;
    [SerializeField] private GroundSensor _groundSensor;
    [SerializeField] private PlayerAnimator _animator;

    private Health _health;
    private PlayerMover _playerMovement;
    private PlayerCombat _playerCombat;
    private InputHandler _inputHandler;
    private bool _isJumping = false;

    public bool IsAlive { get; private set; }

    private void Awake()
    {
        _health = GetComponent<Health>();
        _playerMovement = GetComponent<PlayerMover>();
        _playerCombat = GetComponent<PlayerCombat>();
        _inputHandler = GetComponent<InputHandler>();
        IsAlive = true;
    }

    private void OnEnable()
    {
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
    }

    private void Update()
    {
        if(IsAlive)
        {
            DefineJumping();

            if (_inputHandler.Direction != 0)
                Move();
            else
                _animator.SetSpeed(0);

            if (_inputHandler.GetIsJump() && _groundSensor.IsGrounded)
                Jump();

            if (_inputHandler.GetIsAttack())
                _playerCombat.Attack();
        }
    }

    private void DefineJumping()
    {
        if (_groundSensor.IsGrounded == false && _isJumping)
        {
            _isJumping = false;
            _animator.ChangeGroundedBool(_isJumping);
        }
        else if (_groundSensor.IsGrounded && _isJumping == false)
        {
            _isJumping = true;
            _animator.ChangeGroundedBool(_isJumping);
        }
    }

    private void Move()
    {
        _playerMovement.Move(_inputHandler.Direction);

        if (_groundSensor.IsGrounded)
            _animator.SetSpeed(_playerMovement.Speed);

        _faceDirectioneer.SetFaceDirection(_inputHandler.Direction);
    }

    private void Jump()
    {
        _isJumping = true;
        _playerMovement.Jump();
        _animator.Jump();
    }

    private void Die()
    {
        IsAlive = false;
        _animator.Die();
    }
}