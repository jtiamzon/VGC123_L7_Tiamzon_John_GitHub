using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// reference: https://www.youtube.com/watch?v=E7gmylDS1C4&ab_channel=PressStart
public class deployCollectables : MonoBehaviour
{
    public GameObject collectablePrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y));
        StartCoroutine(collectableWave());
    }

    private void spawnCollectable()
    {
        GameObject a = Instantiate(collectablePrefab) as GameObject;    // added collectable on screen
        a.transform.position = new Vector2(screenBounds.x, Random.Range(-screenBounds.x, screenBounds.x));
    }
    
    IEnumerator collectableWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnCollectable();
        }
    }
}
