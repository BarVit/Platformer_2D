using UnityEngine;

[RequireComponent(typeof(PlayerAnimator), typeof(PlayerMover))]
public class InputHandler : MonoBehaviour
{
    private PlayerMover _playerMover;
    private PlayerAnimator _playerAnimator;
    private string _horizontal = "Horizontal";
    private string _buttonSpace = "space";
    private int _leftButton = 0;

    public float InputX { get; private set; }

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void Update()
    {
        HandleInput();
        SetAnimation();
    }

    private void HandleInput()
    {
        InputX = Input.GetAxis(_horizontal);

        if (Input.GetMouseButtonDown(_leftButton))
            _playerAnimator.Attack();
        else if (Input.GetKeyDown(_buttonSpace))
            _playerMover.Jump();
    }

    private void SetAnimation()
    {
        if (InputX != 0)
            _playerAnimator.SetSpeed(_playerMover.Speed);
        else
            _playerAnimator.SetSpeed(0);
    }
}