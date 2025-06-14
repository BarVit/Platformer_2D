using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private string _horizontal = "Horizontal";
    private string _buttonSpace = "space";
    private int _leftButton = 0;
    private bool _isJump = false;
    private bool _isAttack = false;
    private bool _isCasting = false;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(_horizontal);

        if (Input.GetKeyDown(_buttonSpace))
            _isJump = true;

        if (Input.GetMouseButtonDown(_leftButton))
            _isAttack = true;

        if (Input.GetKeyDown(KeyCode.Q))
            _isCasting = true;
    }

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);
    public bool GetIsAttack() => GetBoolAsTrigger(ref _isAttack);
    public bool GetIsCasting() => GetBoolAsTrigger(ref _isCasting);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;

        value = false;
        return localValue;
    }
}