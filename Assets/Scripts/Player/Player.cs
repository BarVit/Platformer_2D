using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(PlayerCombat), typeof(InputHandler))]
public class Player : MonoBehaviour
{
    [SerializeField] private FaceDirectioneer _faceDirectioneer;
    [SerializeField] private GroundSensor _groundSensor;
    [SerializeField] private PlayerAnimator _playerAnimator;

    private PlayerMover _playerMovement;
    private PlayerCombat _playerCombat;
    private InputHandler _inputHandler;
    private bool _isJumping = false;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMover>();
        _playerCombat = GetComponent<PlayerCombat>();
        _inputHandler = GetComponent<InputHandler>();
    }

    private void Update()
    {
        DefineJumping();

        if (_inputHandler.Direction != 0)
            Move();
        else
            _playerAnimator.SetSpeed(0);

        if (_inputHandler.GetIsJump() && _groundSensor.IsGrounded)
            Jump();

        if (_inputHandler.GetIsAttack())
            _playerCombat.Attack();
    }

    private void DefineJumping()
    {
        if (_groundSensor.IsGrounded == false && _isJumping)
        {
            _isJumping = false;
            _playerAnimator.ChangeGroundedBool(_isJumping);
        }
        else if (_groundSensor.IsGrounded && _isJumping == false)
        {
            _isJumping = true;
            _playerAnimator.ChangeGroundedBool(_isJumping);
        }
    }

    private void Move()
    {
        _playerMovement.Move(_inputHandler.Direction);

        if (_groundSensor.IsGrounded)
            _playerAnimator.SetSpeed(_playerMovement.Speed);

        _faceDirectioneer.SetFaceDirection(_inputHandler.Direction);
    }

    private void Jump()
    {
        _isJumping = true;
        _playerMovement.Jump();
        _playerAnimator.Jump();
    }
}