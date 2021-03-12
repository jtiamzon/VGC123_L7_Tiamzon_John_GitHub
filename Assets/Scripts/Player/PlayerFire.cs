using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]

public class PlayerFire : MonoBehaviour
{
    SpriteRenderer megaManSprite;

    public Transform spawnPointLeft;
    public Transform spawnPointRight;

    public float projectileSpeed;                                           // speed of projectile
    public Projectile projectilePrefab;
    
        // Start is called before the first frame update
        void Start()
        {
        megaManSprite = GetComponent<SpriteRenderer>();

            // protecting from bad input
            if (projectileSpeed <= 0)
            {
                projectileSpeed = 7.0f;
            }

            if (!spawnPointLeft || !spawnPointRight || !projectilePrefab)       // if they are not available
                Debug.Log("Unity Inspector Values Not Set");
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
                FireProjectile();
        }

        void FireProjectile()
        {
            if (megaManSprite.flipX)                                              // if Mario is flipped
            {
                // Debug.Log("Fire Right Side");
                Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointRight.position, spawnPointRight.rotation);      // Projectile projectileInstance --> storing the Instantiate into a variable to
                                                                                                                                        // gain access to its public variables
                projectileInstance.speed = projectileSpeed;
            }
            else                                                                // if Mario is not flipped
            {
                // Debug.Log("Fire Left Side");
                Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);        // Instantiate: takes templated type (Projectile) and a reference to object
                                                                                                                                        // and Vector3 position, and its rotation to create the object
                projectileInstance.speed = -projectileSpeed;
            }


        }
    }
