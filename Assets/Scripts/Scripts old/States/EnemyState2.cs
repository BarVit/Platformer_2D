using UnityEngine;

public abstract class EnemyState2 : MonoBehaviour
{
    [SerializeField] protected EnemyAnimator Animator;
    [SerializeField] protected FaceDirectioneer SpriteDirection;
    [SerializeField] protected EnemyMover Mover;

    public Player Target { get; protected set; }
    public bool IsBlocked { get; protected set; }

    public virtual void Do() { }
    public virtual void Enter() { }
    public virtual void Enter(Player target) { }
    public virtual void Exit() { }
}