using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inekhareket : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;
    [SerializeField] Rigidbody2D Rigidbody2D;
    public float speed = 2f;

    private bool movingRight = true;

    void FixedUpdate()
    {
        Vector2 newPosition = Rigidbody2D.position;
        if (movingRight)
        {
            newPosition += Vector2.right * speed * Time.fixedDeltaTime;

            if (newPosition.x >= rightPoint.position.x)
            {
                movingRight = false;
            }
        }
        else
        {
            newPosition += Vector2.left * speed * Time.fixedDeltaTime;

            if (newPosition.x <= leftPoint.position.x)
            {
                movingRight = true;
            }
        }
        Rigidbody2D.MovePosition(newPosition);

    }
}
