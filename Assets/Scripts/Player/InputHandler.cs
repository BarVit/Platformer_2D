using UnityEngine;

[RequireComponent(typeof(PlayerAnimator), typeof(PlayerMover))]
public class InputHandler : MonoBehaviour
{
    private PlayerAnimator _animatorLogic;
    private PlayerMover _playerMover;
    private string _horizontal = "Horizontal";
    private string _buttonSpace = "space";
    private int _leftButton = 0;

    public float InputX { get; private set; }

    private void Awake()
    {
        _animatorLogic = GetComponent<PlayerAnimator>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        HandleInput();

        if (InputX != 0)
            _animatorLogic.SetSpeed(_playerMover.Speed);
        else
            _animatorLogic.SetSpeed(0);
    }

    private void HandleInput()
    {
        InputX = Input.GetAxis(_horizontal);

        if (Input.GetMouseButtonDown(_leftButton))
        {
            _animatorLogic.Attack();
        }
        else if (Input.GetKeyDown(_buttonSpace))
        {
            _playerMover.Jump();
        }
    }
}