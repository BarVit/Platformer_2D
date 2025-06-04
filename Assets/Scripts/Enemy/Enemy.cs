using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private CapsuleCollider2D _capsuleCollider2D;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _stateMachine.Run();
    }

    private void OnEnable()
    {
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
    }

    private void Die()
    {
        _rigidbody2D.gravityScale = 0;
        Destroy(_capsuleCollider2D);
        _stateMachine.Stop();
        _animator.Die();
    }
}