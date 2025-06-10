using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    public float speed = 5f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //Debug.Log($"Horizontal: {horizontalInput}, Vertical: {verticalInput}");
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 newVelocity = new Vector2(horizontalInput, verticalInput).normalized * speed;
        rb.velocity = newVelocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Finish"))
        {
            LevelComplete();
        }
    }

    private void LevelComplete()
    {
        Debug.Log("Level Complete!");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            PlayerDied();
        }
    }

    private void PlayerDied()
    {
        Destroy(gameObject);
    }
}
