using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(PlayerCombat), typeof(InputHandler))]
[RequireComponent(typeof(Health))]
public class PlayerActivity : MonoBehaviour
{
    [SerializeField] private GroundSensor _groundSensor;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private FaceDirectioneer _faceDirectioneer;

    private PlayerMover _playerMovement;
    private PlayerCombat _playerCombat;
    private InputHandler _inputHandler;
    private Health _health;
    private bool _isJumping = false;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMover>();
        _playerCombat = GetComponent<PlayerCombat>();
        _inputHandler = GetComponent<InputHandler>();
        _health = GetComponent<Health>();
    }

    public void Run()
    {
        if (_health.Value > 0)
        {
            DefineJumping();

            if(_playerCombat.IsCasting == false)
            {
                if (_inputHandler.Direction != 0)
                    Move();
                else
                    StayIdle();

                if (_inputHandler.GetIsJump() && _groundSensor.IsGrounded)
                    Jump();

                if (_inputHandler.GetIsAttack())
                    _playerCombat.Attack();
            }

            if (_inputHandler.GetIsCasting() && _groundSensor.IsGrounded)
                _playerCombat.CastSpell();
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
            _animator.SetSpeed(_inputHandler.Direction);

        _faceDirectioneer.SetFaceDirection(_inputHandler.Direction);
    }

    private void Jump()
    {
        _isJumping = true;
        _playerMovement.Jump();
        _animator.Jump();
    }

    private void StayIdle()
    {
        _animator.SetSpeed(0);
    }
}