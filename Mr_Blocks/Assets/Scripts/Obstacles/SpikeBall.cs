using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour
{

    void Start()
    {
        Debug.Log("Start Called!");
    }
    public float rotationAngle = 90f;
    private void Update() => RotateSpikeBall();
    private void RotateSpikeBall() => transform.Rotate(Vector3.forward, rotationAngle);
}
