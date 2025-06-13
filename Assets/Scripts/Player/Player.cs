using UnityEngine;

[RequireComponent(typeof(Health), typeof(PlayerActivity))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _animator;

    private Health _health;
    private PlayerActivity _playerActivity;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _playerActivity = GetComponent<PlayerActivity>();
    }

    private void OnEnable()
    {
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
    }

    private void Update()
    {
        _playerActivity.Run();
    }

    private void Die()
    {
        _animator.Die();
    }
}