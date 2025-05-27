using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inekhareket : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    private Vector2 previousPosition;

    public Transform leftPoint;
    public Transform rightPoint;
    public Transform topPoint;
    public Transform lastPoint;
    [SerializeField] Rigidbody2D Rigidbody2D;
    public float speed = 1f;

    private PlayerInventory playerInventory; 

    private bool movingRight = true;
    void Start()
    {
        previousPosition = Rigidbody2D.position;
    }
    void Update()
    {
        if (playerInventory == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerInventory = player.GetComponent<PlayerInventory>();
                Debug.Log("Player bulundu");
            }
        }
    }
    void FixedUpdate()
    {
        
        if (playerInventory != null && !playerInventory.kapiyiActi)
        {
            animator.SetBool("isWalkingHorizontal", true);
            animator.SetBool("isWalkingDown", false);
            Vector2 newPosition = Rigidbody2D.position;

            if (movingRight)
            {
                spriteRenderer.flipX = true;
                newPosition += Vector2.right * speed * Time.fixedDeltaTime;

                if (newPosition.x >= rightPoint.position.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                spriteRenderer.flipX = false;
                newPosition += Vector2.left * speed * Time.fixedDeltaTime;

                if (newPosition.x <= leftPoint.position.x)
                {
                    movingRight = true;
                }
            }

            Rigidbody2D.MovePosition(newPosition);
        }
        else if (playerInventory != null && playerInventory.kapiyiActi)
        {
            Vector2 position = Rigidbody2D.position;

            if (Mathf.Abs(position.x - topPoint.position.x) > 0.05f)
            {
                animator.SetBool("isWalkingHorizontal", true);
                animator.SetBool("isWalkingDown", false);

                if (position.x < topPoint.position.x)
                {
                    spriteRenderer.flipX = true;
                    position += Vector2.right * speed * Time.fixedDeltaTime;
                }
                else
                {
                    spriteRenderer.flipX = false;
                    position += Vector2.left * speed * Time.fixedDeltaTime;
                }

                Rigidbody2D.MovePosition(position);
            }
            else
            {
                if (position.y > lastPoint.position.y)
                {
                    animator.SetBool("isWalkingHorizontal", false);
                    animator.SetBool("isWalkingDown", true);
                    animator.SetBool("isWalking", true);
                    spriteRenderer.flipX = false;
                    position += Vector2.down * speed * Time.fixedDeltaTime;
                    Rigidbody2D.MovePosition(position);
                }
                else
                {
                    animator.SetBool("isWalking", false);
                    Rigidbody2D.bodyType = RigidbodyType2D.Static;
                }
            }
        }
        Vector2 currentPosition = Rigidbody2D.position;
        bool isMoving = Vector2.Distance(currentPosition, previousPosition) > 0.001f;
        boxCollider.isTrigger = isMoving;
        previousPosition = currentPosition;
    }
}
