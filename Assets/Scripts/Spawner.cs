using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject player;

    private float h;
    private float s;
    private float v;

    private void Awake()
    {
        h = 36;
        s = 53;
        v = 100;
    }

    public void SpawnObstacle(Vector3 pos)
    {
        var x = Random.Range(-6, 6);
        GameObject obstacle = Instantiate(obstaclePrefab);
        obstacle.transform.position = new Vector3(x, pos.y, pos.z);

        h += 3;
        if (h >= 100)
            h = 36;

        var col = Color.HSVToRGB(h / 100, s / 100, v / 100);
        obstacle.transform.GetChild(0).GetComponent<SpriteRenderer>().color = col;
        obstacle.transform.GetChild(1).GetComponent<SpriteRenderer>().color = col;
        Destroy(obstacle, 30);
    }

}
