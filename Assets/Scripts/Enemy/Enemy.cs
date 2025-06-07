using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D), typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private EnemyAnimator _animator;

    private Health _health;
    private CapsuleCollider2D _capsuleCollider2D;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
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