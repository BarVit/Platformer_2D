using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _animator;

    public void Attack()
    {
        _animator.Attack();
    }
}