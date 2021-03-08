using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovementFalse : MonoBehaviour
{
    public float startSpeed = 3f;
    public float border = 2.45f;
    private static bool moveleft = true;
    public GameObject menu;
    private float timer;
    private float speed;
    private void Awake()
    {
        timer = 0;
    }

    void Update()
    {

        timer += Time.deltaTime;
        speed = startSpeed + timer * 0.1f;
        
        if (transform.position.x > -border && moveleft)
        {
            transform.position -= new Vector3(Time.deltaTime * speed, -Time.deltaTime*speed/2, 0);
        }
        else
        {
            moveleft = false;
            transform.position += new Vector3(Time.deltaTime * speed, Time.deltaTime*speed/2, 0);

            if (transform.position.x > border)
                moveleft = true;
        }
    }

}
