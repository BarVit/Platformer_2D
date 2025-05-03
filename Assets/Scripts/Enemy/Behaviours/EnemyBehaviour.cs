using UnityEngine;

public abstract class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] protected EnemyAnimator Animator;
    [SerializeField] protected FaceDirectioneer SpriteDirection;
    [SerializeField] protected EnemyMover Mover;

    public Player Target { get; protected set; }
    public bool IsComplete { get; protected set; }

    public virtual void Awake()
    {
        IsComplete = false;
    }

    public virtual void Enter() { }
    public virtual void Do() { }
    public virtual void Exit() { }

    public void SetTarget(Player target)
    {
        Target = target;
    }
}