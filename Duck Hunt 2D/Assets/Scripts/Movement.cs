using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Transform pointer;
    [SerializeField] private float moveSpeed;
    [SerializeField] LayerMask WhatIsWall;


    private Rigidbody2D rb2d;
    private bool moveRight = true;
    private float distance = 0.3f;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Debug.DrawLine(pointer.position, rb2d.position, Color.yellow);

        if (moveRight)
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
        }
        CheckCollision();
    }

    private void CheckCollision()
    {
        if (Physics2D.Raycast(pointer.position, Vector2.right, distance, WhatIsWall))
        {
            ChangeDirection();
        }
    }
    private void ChangeDirection()
    {
        moveRight = !moveRight;

        Vector3 tempScale = transform.localScale;
        if (moveRight)
        {
            tempScale.x = Mathf.Abs(tempScale.x);
        }
        else
        {
            tempScale.x = -Mathf.Abs(tempScale.x);
        }
        transform.localScale = tempScale;
    }

}//Class
