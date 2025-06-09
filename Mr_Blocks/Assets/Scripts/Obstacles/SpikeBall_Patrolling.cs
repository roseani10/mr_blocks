using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall_Patrolling : MonoBehaviour
{
    public float rotationAngle = 90f;
    float patrolSpeed = 2f;
    public Vector3 pointA;
    public Vector3 pointB;
    private Vector3 targetPoint;

    private void Start()
    {
        SetPatrolPoints();
    }
    private void Update()
    {
        RotateSpikeBall();
        PatrolSpikeBall();
    }
    private void RotateSpikeBall() => transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);

    private void PatrolSpikeBall()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, patrolSpeed * Time.deltaTime);
        if(transform.position == targetPoint)
        {
            targetPoint = (targetPoint == pointA) ? pointB : pointA;
        }
    }

    private void SetPatrolPoints()
    {
        transform.position = pointA;
        targetPoint = pointB;
    }
}
