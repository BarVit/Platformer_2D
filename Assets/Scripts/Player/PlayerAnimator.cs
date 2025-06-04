using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private int _speedHash = Animator.StringToHash("speed");
    private int _groundedHash = Animator.StringToHash("grounded");
    private int _jumpHash = Animator.StringToHash("jump");
    private int _attackHash = Animator.StringToHash("attack");
    private int _deathHash = Animator.StringToHash("death");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Jump()
    {
        _animator.SetTrigger(_jumpHash);
        _animator.SetBool(_groundedHash, true);
    }

    public void Attack()
    {
        _animator.SetTrigger(_attackHash);
    }

    public void ChangeGroundedBool(bool grounded)
    {
        _animator.SetBool(_groundedHash, grounded);
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(_speedHash, speed);
    }

    public void Die()
    {
        _animator.SetTrigger(_deathHash);
    }
}