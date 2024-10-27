using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimatorLogic : MonoBehaviour
{
    private Animator _animator;
    private string _animatorSpeed = "speed";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(_animatorSpeed, speed);
    }
}