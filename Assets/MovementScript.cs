using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float playerSpeed = 10;
    public float playerJump = 10;

    public Rigidbody2D rb;

    private float Move;

    public bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(playerSpeed * Move, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            rb.velocity += Vector2.up * playerJump;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = true;
        }
    }
}