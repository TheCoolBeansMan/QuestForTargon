using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public LayerMask wallLayer;
    public float moveDistance = 1f;
    private int stepsRemaining;

    public void SetSteps(int steps)
    {
        stepsRemaining = steps;
    }

    public bool Move(Vector2Int direction)
    {
        if (!CanMove(direction)) return false;

        Vector3 targetPos = transform.position + new Vector3(direction.x, direction.y, 0) * moveDistance;
        transform.position = targetPos;
        return true;
    }

    public bool CanMove(Vector2Int direction)
    {
        Vector3 origin = transform.position;
        Vector3 dir = new Vector3(direction.x, direction.y, 0);
        Ray ray = new Ray(origin, dir);
        // Draw the ray in the Scene view (red if hit, green if clear)
        Color rayColor = Physics.Raycast(origin, dir, moveDistance, wallLayer) ? Color.red : Color.green;
        Debug.DrawRay(origin, dir * moveDistance, rayColor, 0.5f); // 0.5 seconds visible

        return !Physics.Raycast(ray, moveDistance, wallLayer);
    }
}
