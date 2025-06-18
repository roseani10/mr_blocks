using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall_Scaling : MonoBehaviour
{
    public float rotationAngle = 90f;
    private float scalingFactor = 1f;   // Controls scaling direction
    private float currentScale;        // Current scale value
    public float scalingSpeed = 15f;   // Speed at which the spike scales
    public float minScale = 0.5f;      // Minimum size
    public float maxScale = 1.5f;      // Maximum size

    public float scaleDelay = 2f;  // Delay between scaling up and down
    private bool isWaiting = false;  // Is the spike in a waiting state?
    private float timer = 0f;  // Tracks the waiting period

    private void Start()
    {
        currentScale = minScale;
        ApplyCurrentScale();
        //Debug.Log("Inside Start End!");
    }
    private void Update()
    {
        RotateSpikeBall();
        if (isWaiting)
            HandleWaiting();
        else
            ScaleSpikeBall();
    }

    private void RotateSpikeBall()
    {
        transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);
    }

    private void ScaleSpikeBall()
    {
        currentScale += scalingFactor * scalingSpeed * Time.deltaTime;
        currentScale = Mathf.Clamp(currentScale, minScale, maxScale);
        if (currentScale >= maxScale || currentScale <= minScale)
        {
            scalingFactor = -scalingFactor;
            isWaiting = true;
        }
        ApplyCurrentScale();
    }

    private void ApplyCurrentScale()
    {
        transform.localScale = new Vector3(currentScale, currentScale, 1);
    }

    private void HandleWaiting()
    {
        timer += Time.deltaTime;
        if (timer >= scaleDelay)
        {
            isWaiting = false;
            timer = 0f;
        }
    }
}
