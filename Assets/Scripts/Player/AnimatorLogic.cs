using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorLogic : MonoBehaviour
{
    private Animator _animator;
    private string _animatorSpeed = "speed";
    private string _animatorGrounded = "grounded";
    private string _animatorJump = "jump";
    private string _animatorAttack = "attack";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Jump()
    {
        _animator.SetTrigger(_animatorJump);
        _animator.SetBool(_animatorGrounded, true);
    }

    public void Attack()
    {
        _animator.SetTrigger(_animatorAttack);
    }

    public void ChangeGroundedBool(bool grounded)
    {
        _animator.SetBool(_animatorGrounded, grounded);
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(_animatorSpeed, speed);
    }
}