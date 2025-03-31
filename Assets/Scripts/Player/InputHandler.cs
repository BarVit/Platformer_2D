using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class InputHandler : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _animator;

    private PlayerMover _mover;
    private string _horizontal = "Horizontal";
    private string _buttonSpace = "space";
    private int _leftButton = 0;

    public float InputX { get; private set; }

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
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
            _animator.Attack();
        else if (Input.GetKeyDown(_buttonSpace))
            _mover.Jump();
    }

    private void SetAnimation()
    {
        if (InputX != 0)
            _animator.SetSpeed(_mover.Speed);
        else
            _animator.SetSpeed(0);
    }
}