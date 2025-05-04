using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    [SerializeField] protected EnemyAnimator Animator;
    [SerializeField] protected FaceDirectioneer SpriteDirection;
    [SerializeField] protected EnemyMover Mover;

    public Player Target { get; protected set; }
    public bool IsComplete { get; protected set; }

    public abstract void Enter();
    public abstract void Do();
    public abstract void Exit();

    public virtual void Awake()
    {
        IsComplete = false;
    }

    public void SetTarget(Player target)
    {
        Target = target;
    }
}