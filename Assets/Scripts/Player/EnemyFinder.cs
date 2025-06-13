using System.Linq;
using UnityEngine;
using System;

public class EnemyFinder : MonoBehaviour
{
    private const string LayerName = "Units";
    private LayerMask _layerMask;
    private float _findingRadius = 4f;

    private void Awake()
    {
        _layerMask = LayerMask.GetMask(LayerName);
    }

    public Health GetTarget()
    {
        Health target;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _findingRadius, _layerMask);
        Health[] enemies = colliders.Where(collider => collider.GetComponent<Enemy>() != null)
            .Select(collider => collider.GetComponent<Health>()).ToArray();
        float[] distances = new float[enemies.Length];

        if(enemies.Length > 0)
        {
            for (int i = 0; i < enemies.Length; i++)
                distances[i] = Vector2.Distance(transform.position, enemies[i].transform.position);

            target = enemies[Array.IndexOf(distances, distances.Min())];
        }
        else
        {
            target = null;
        }

        return target;
    }
}