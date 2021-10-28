using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public List<GameObject> spawnPool;
    public int timeInterval;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawn", 0, timeInterval);
    }

    public void spawn()
    {
        GameObject spawned = spawnPool[Random.Range(0, spawnPool.Count)];

        int y_position = Random.Range((int)Camera.main.transform.position.y + (int)Camera.main.orthographicSize, (int)Camera.main.transform.position.y - (int)Camera.main.orthographicSize);
        int x_position = (int)(Camera.main.transform.position.x + Camera.main.aspect * Camera.main.orthographicSize * 1.3f);

        Vector2 position = new Vector2(x_position, y_position);

        Instantiate(spawned, position, spawned.transform.rotation);
    }

}
