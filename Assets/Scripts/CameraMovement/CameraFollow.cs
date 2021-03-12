using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;
    // public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // store camera position in variable temp
       Vector3 temp = transform.position;

        // set camera position's x to equal player's x position
        temp.x = playerTransform.position.x - 0.1f;
        temp.x = Mathf.Clamp(temp.x, 0, 13.18f);
        temp.y = playerTransform.position.y;

        transform.position = temp;

        /* if (player)
        {
            Vector3 cameraTransform;
            cameraTransform = transform.position;
            cameraTransform.x = player.transform.position.x - 7.4f;
            cameraTransform.x = Mathf.Clamp(cameraTransform.x, 0, 13.18f);
            transform.position = cameraTransform;
        } */
    }
}
