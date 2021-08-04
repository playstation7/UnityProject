using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement.x = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
