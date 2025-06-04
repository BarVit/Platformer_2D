using UnityEngine;
using System;

public class TargetFinder : MonoBehaviour
{
    public Player Target { get; private set; }

    private const string LayerName = "Units";
    private LayerMask _layerMask;
    Vector2 bottomLeft;
    Vector2 topRight;
    float horizontalOffset = 4f;
    float topOffset = 1f;
    float bottomOffset = -0.5f;

    private void Awake()
    {
        _layerMask = LayerMask.GetMask(LayerName);
    }

    private void Update()
    {
        Player player = null;
        Collider2D[] colliders;
        Collider2D playerCollider;

        bottomLeft = transform.position - new Vector3(horizontalOffset, bottomOffset, 0);
        topRight = transform.position + new Vector3(horizontalOffset, topOffset, 0);
        colliders = Physics2D.OverlapAreaAll(topRight, bottomLeft, _layerMask);
        playerCollider = Array.Find(colliders, collider => collider.GetComponent<Player>() != null);

        if (playerCollider != null)
            player = playerCollider.GetComponent<Player>();

        Target = player;
    }

    //private void OnDrawGizmos()
    //{
    //    DrawRectange(topRight, bottomLeft);
    //}

    //public void DrawRectange(Vector2 top_right_corner, Vector2 bottom_left_corner)
    //{
    //    Vector2 center_offset = (top_right_corner + bottom_left_corner) * 0.5f;
    //    Vector2 displacement_vector = top_right_corner - bottom_left_corner;
    //    float x_projection = Vector2.Dot(displacement_vector, Vector2.right);
    //    float y_projection = Vector2.Dot(displacement_vector, Vector2.up);

    //    Vector2 top_left_corner = new Vector2(-x_projection * 0.5f, y_projection * 0.5f) + center_offset;
    //    Vector2 bottom_right_corner = new Vector2(x_projection * 0.5f, -y_projection * 0.5f) + center_offset;

    //    Gizmos.DrawLine(top_right_corner, top_left_corner);
    //    Gizmos.DrawLine(top_left_corner, bottom_left_corner);
    //    Gizmos.DrawLine(bottom_left_corner, bottom_right_corner);
    //    Gizmos.DrawLine(bottom_right_corner, top_right_corner);
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.TryGetComponent(out Player player))
    //        if(player.IsAlive)
    //            SetTarget(player);
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.GetComponent<Player>() != null)
    //        SetTarget(null);
    ////}

    //private void SetTarget(Player target)
    //{
    //    Target = target;
    //}
}