using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public float speed;         // speed of projectile
    public float lifetime;      // lifetime of projectile

    // Start is called before the first frame update
    void Start()
    {
        if (lifetime <= 0)
        {
                lifetime = 2.0f; // anytime a decimal is used, 'f' must be used to convert to 'float'
        }

            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
            Destroy(gameObject, lifetime);           // destroying 'projectile' at its lifetime (2 sec by default)
    }

   private void OnCollisionEnter2D(Collision2D collision)
    {
       /* if (collision.gameObject.tag != "Player")    // if I'm not equal to the player
            Destroy(gameObject); */

        if (collision.gameObject.layer == 3)
        {
            Destroy(gameObject);
        }

        // if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Squished")               // only if we have a squished collider (mentioned in Week7 video)
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyWalker>().IsDead();
            Destroy(gameObject);
        }
    }
}