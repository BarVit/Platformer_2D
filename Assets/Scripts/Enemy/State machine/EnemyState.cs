using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    [SerializeField] protected TargetFinder TargetFinder;
    [SerializeField] protected EnemyAnimator Animator;
    [SerializeField] protected FaceDirectioneer SpriteDirection;
    [SerializeField] protected EnemyMover Mover;

    protected StateMachine StateMachine;

    public abstract EnemyState RunState();

    public virtual void Enter() { }
    public virtual void Exit() { }
}