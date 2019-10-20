using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObsticles : MonoBehaviour
{
    private const float maxTime = 4f;
    private float timer = 0;
    public GameObject obsticle;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        GameObject newObsticle = Instantiate(obsticle);
        newObsticle.transform.position = transform.position + new Vector3(Random.Range(0f, 3.5f), player.transform.position.y + 6, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            GameObject newObsticle = Instantiate(obsticle);
            newObsticle.transform.position = transform.position + new Vector3(Random.Range(0, 3.5f), player.transform.position.y+6 , 0);
            Destroy(newObsticle, 15);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
