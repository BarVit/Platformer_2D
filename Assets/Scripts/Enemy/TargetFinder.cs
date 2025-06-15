using UnityEngine;
using System.Linq;
using System.Collections;

public class TargetFinder : MonoBehaviour
{
    public Health Target { get; private set; }

    private const string LayerName = "Units";
    private Coroutine _targetFinder;
    private LayerMask _layerMask;
    private float _horizontalOffset = 4f;
    private float _topOffset = 0.25f;
    private float _bottomOffset = 0.25f;
    private float _findingRate = 0.2f;
    private bool _isFinding;

    private void Awake()
    {
        _layerMask = LayerMask.GetMask(LayerName);
    }

    private void Update()
    {
        if(_isFinding == false)
        {
            _isFinding = true;
            _targetFinder = StartCoroutine(FindTarget());
        }
    }

    private IEnumerator FindTarget()
    {
        float delay = _findingRate;
        Vector2 topRight = transform.position + new Vector3(_horizontalOffset, _topOffset, 0);
        Vector2 bottomLeft = transform.position - new Vector3(_horizontalOffset, _bottomOffset, 0);
        Collider2D[] colliders = Physics2D.OverlapAreaAll(topRight, bottomLeft, _layerMask);

        Target = colliders.Where(collider => collider.GetComponent<Player>() != null)
            .Select(collider => collider.GetComponent<Health>()).FirstOrDefault();

        while (delay > 0)
        {
            delay -= Time.deltaTime;

            yield return null;
        }

        _isFinding = false;
    }
}