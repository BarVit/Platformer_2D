using UnityEngine;

public class EnemyDeadBody : MonoBehaviour
{
    [SerializeField] private EnemyAnimator _animator;

    private float _timeToDestroy = 5f;

    public void Die()
    {
        _animator.Die();
        Destroy(gameObject, _timeToDestroy);
    }
}