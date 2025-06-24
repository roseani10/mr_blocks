using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour
{

    void Start()
    {
        Debug.Log("Start Called!");
        DoSomething();
    }

    void DoSomething()
    {
        Debug.Log("Doing it first time.");
        RotateSpikeBall();
    }
    public float rotationAngle = 90f;
    private void Update()
    {
        Debug.Log("Inside Update.");
        RotateSpikeBall();
    }
    private void RotateSpikeBall()
    {
        //Debug.Log("Inside Rotate Spike Ball.");
        transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);
    }
}
