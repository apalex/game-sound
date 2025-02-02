using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movements;
    public SpriteRenderer spriteRenderer; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movements.x = Input.GetAxisRaw("Horizontal");
        movements.y = Input.GetAxisRaw("Vertical");
        if (movements.x > 0)
        {
            spriteRenderer.flipX = false; 
        }
        else if (movements.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
    void FixedUpdate()
    {
        rb.velocity = movements.normalized * moveSpeed;
    }
}
