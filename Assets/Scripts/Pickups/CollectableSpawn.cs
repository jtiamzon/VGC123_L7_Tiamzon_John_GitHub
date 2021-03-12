using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// reference: https://www.youtube.com/watch?v=E7gmylDS1C4&ab_channel=PressStart
public class CollectableSpawn : MonoBehaviour
{
    private BoxCollider2D bc;
    private Vector2 screenBounds;
    
    // Start is called before the first frame update
    void Start()
    {
        bc = this.GetComponent<BoxCollider2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y));
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x, screenBounds.x * -1);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y, screenBounds.y * -1);
        transform.position = viewPos;
        
        if (transform.position.x > screenBounds.x )
            Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.gameObject.tag == "Barriers")
            Destroy(gameObject);  
    }
        

}
