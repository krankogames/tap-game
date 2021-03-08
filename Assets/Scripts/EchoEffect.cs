using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{
    public float startTimeBtwSpawns;
    private float timeBtwSpawns;
    public GameObject echo;

    public void Update()
    {
        if(timeBtwSpawns<0)
        {
            var e=Instantiate(echo);
            e.transform.position = transform.position;
            Destroy(e,5f);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }    
    }
}
