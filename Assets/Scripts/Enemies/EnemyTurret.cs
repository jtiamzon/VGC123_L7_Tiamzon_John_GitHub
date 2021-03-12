using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

// Note: projectile when flipped still shoots unflipped projectile AND flipped projectile for some reason.

public class EnemyTurret : MonoBehaviour
{
    public Transform projectileLeftSpawnPoint;
    public Transform projectileRightSpawnPoint;
    public Projectile projectilePrefab;

    public float projectileForce;

    public float projectileFireRate;
    float timeSinceLastFire = 0.0f;
    public int health;

    public GameObject target = null;
    public bool shootLeft;

    Animator anim;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        if (projectileForce <= 0)
        {
            projectileForce = 7.0f;
        }

        if (health <= 0)
        {
            health = 5;
        }

        if (!target)
        {
            target = GameObject.FindWithTag("Player");

            shootDirectionCheck();
        }
    }

    // Update is called once per frame
    /* void Update()
    {
        if (Time.time >= timeSinceLastFire + projectileFireRate)
        {
            anim.SetBool("Fire", true);
            timeSinceLastFire = Time.time;
        }
    } */

    void shootDirectionCheck()
    {
        if (target.transform.position.x < transform.position.x)     // if target position is less than the EnemyTurret position
        {
            Debug.Log("shoot left");
            sr.flipX = sr.flipX;
            shootLeft = true;   // shoots left
        }
        else
        {
            Debug.Log("shoot right");
            sr.flipX = !sr.flipX;
            shootLeft = false;  // shoots right
        }
    }

    public void Fire()
    {
        // projectile will be fired from here
        Projectile temp = Instantiate(projectilePrefab, projectileLeftSpawnPoint.position, projectileLeftSpawnPoint.rotation);
        temp.speed = projectileForce;
    }

    void fireProjectile()
    {
        shootDirectionCheck();
        if (shootLeft)
        {
            Instantiate(projectilePrefab, projectileLeftSpawnPoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        else
        {
           Instantiate(projectilePrefab, projectileRightSpawnPoint.position, Quaternion.Euler(new Vector3(0, 180.0f, 0)));
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(Time.time > timeSinceLastFire + projectileFireRate)
            {
                fireProjectile();
                anim.SetBool("Fire", true);
                timeSinceLastFire = Time.time;
            }
        }
    }

    public void ReturnToIdle()
    {
        anim.SetBool("Fire", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            health--;
            Destroy(collision.gameObject);
            if (health <=0)
            {
                Destroy(gameObject);
            }
        }
    }
}
