using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerCollision : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerMovement pm;

    public float bounceForce;   // when you jump on someone's head
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // pm = GetComponent<>(PlayerMovement);

        if (bounceForce <= 0)
        {
            bounceForce = 20.0f;
        }
    }


    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Squished")     // if we hit squish collider
        {
            if (!pm.isGrounded)     // if playermovement is not grounded (false)
            {
                collision.gameObject.GetComponentInParent<EnemyWalker>().IsSquished();
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * bounceForce);
            }
        }
    }
    */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            GameManager.instance.lives--;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.instance.lives--;
        }
    }
}
