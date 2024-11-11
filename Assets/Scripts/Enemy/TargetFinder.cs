using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    [SerializeField] private BehaviourController _behaviourController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth player))
        {
            _behaviourController.SetAttackBehaviour(player);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerHealth>() != null)
        {
            _behaviourController.SetPatrolBehaviour();
        }
    }
}