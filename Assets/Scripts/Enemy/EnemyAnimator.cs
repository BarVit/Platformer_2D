using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;
    private int _speedHash = Animator.StringToHash("speed");
    private int _attackHash = Animator.StringToHash("attack");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(_speedHash, speed);
    }

    public void Attack()
    {
        _animator.SetTrigger(_attackHash);
    }
}