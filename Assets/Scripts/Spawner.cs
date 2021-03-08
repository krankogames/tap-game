using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float obstacleTimer = 4f;
    private float timer = 0;
    public GameObject obstaclePrefab;
    public GameObject player;
    void Update()
    {
        if (timer > obstacleTimer)
        {
            GameObject obstacle = Instantiate(obstaclePrefab);
            obstacle.transform.position = new Vector3(Random.Range(0, 3f), player.transform.position.y + 15, 0);
            Destroy(obstacle, 30);
            timer = 0;
            obstacleTimer-= 0.05f;
        }

        timer += Time.deltaTime;
    }
}
