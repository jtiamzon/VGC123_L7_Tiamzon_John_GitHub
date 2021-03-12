using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class EnemyWalker : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    public int health;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if (speed <= 0)
        {
            speed = 1.0f;
        }
        if (health <= 0)
        {
            health = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if (!anim.GetBool("Death") && !anim.GetBool("Squished"))
        //{
            if (sr.flipX)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Barrier") ;
        {
            sr.flipX = !sr.flipX;       // turns enemy around
        }
    }

   public void IsDead()
    {
        health--;
        if (health <= 0)
        {
            // anim.SetBool("Death", true);
            // rb.velocity = Vector2.zero       // if you die you don't slide like crazy
        }
    }
    /*
    public void IsSquished()
     * {
     *      anim.SetBool("Squish", true);
     * }
     */
    public void FinishedDeath()
    {
        // Destroy(gameObject, 2.0f);   // will kill enemy after 2 seconds
    }
     

    
}
