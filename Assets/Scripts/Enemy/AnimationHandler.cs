using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public bool IsAttacking { get; private set; }

    private void Awake()
    {
        IsAttacking = false;
    }

    public void StartAttackAnimation()
    {
        IsAttacking = true;
    }

    public void StopAttackAnimation()
    {
        IsAttacking = false;
    }
}