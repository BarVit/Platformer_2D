using UnityEngine;

public class PlayerDeadBody : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _animator;

    public void Die()
    {
        _animator.Die();
    }
}