using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public enum CollectibleType
    {
        POWERUP,
        COLLECTABLE,
        LIVES,
        KEY                         // don't have a 'key' collectable, but will be used if needed to collect and store in inventory
    }

    public CollectibleType currentCollectible;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (currentCollectible)
            {
                case CollectibleType.COLLECTABLE:
                    Debug.Log("Collectable");
                    GameManager.instance.score++;
                    // collision.GetComponent<PlayerMovement>().score++;       // will grab component from PlayerMovement.cs and att +1 to score
                    Destroy(gameObject);
                    break;

                case CollectibleType.LIVES:
                    // Debug.Log("Lives");
                    GameManager.instance.lives++;
                    // collision.GetComponent<PlayerMovement>().lives++;  ---> since the GameManager.instance makes it easier to retrieve lives
                    Destroy(gameObject);
                    break;

                case CollectibleType.POWERUP:
                    Debug.Log("PowerUp");
                    collision.GetComponent<PlayerMovement>().StartJumpForceChange();
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
