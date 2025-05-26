using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuKontrol : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public float moveSpeed = 3.0f;
    Vector2 movement;
    Vector2 lastMoveDirection = Vector2.down;
    SpriteRenderer rbSprite;
    void Start()
    {
        rb = GetComponent <Rigidbody2D>();
        animator = GetComponent <Animator>();
        rbSprite = GetComponent <SpriteRenderer>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal",movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        if (movement != Vector2.zero)
        {
            lastMoveDirection = movement.normalized;
        }

        animator.SetFloat("IdleX", lastMoveDirection.x);
        animator.SetFloat("IdleY", lastMoveDirection.y);
    }
    void FixedUpdate()
    {
        if (movement.x < 0)
            rbSprite.flipX = true;
        else if (movement.x > 0)
            rbSprite.flipX = false;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
