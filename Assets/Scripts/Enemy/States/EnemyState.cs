using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    [SerializeField] protected EnemyAnimator Animator;
    [SerializeField] protected FaceDirectioneer SpriteDirection;
    [SerializeField] protected EnemyMover Mover;

    public virtual void SetTarget(Player target) { }

    public virtual void Do() { }
    public virtual void Enter() { }
    public virtual void Exit() { }
}