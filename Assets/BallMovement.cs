using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    private float speed = 3f;
    private float jumpHeight = 5;
    private readonly Vector3 move=new Vector3(0, 1f, 0);
    private static bool moveleft = true;
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.05f;
    public GameObject menu;

    void Awake()
    {
    }

    void Update()
    {
        Move();
        OnTouch();
    }

    private void OnTouch()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.anyKey)
        {
            //var newPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            //newPos.z = 0f;
            Vector3 target=transform.position+move;
            transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothTime);
            //transform.position += new Vector3(Time.deltaTime * 0.5f, 0, 0);
        }
    }

    private void Move()
    {
        if(transform.position.x>-2.45 && moveleft)
        {
            transform.position -= new Vector3(Time.deltaTime * speed, -Time.deltaTime, 0);
        }
        else
        {
            moveleft = false;
            transform.position += new Vector3(Time.deltaTime * speed,Time.deltaTime, 0);

            if (transform.position.x > 2.45)
                moveleft = true;}
       
    }

    //game over
    void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
        menu.SetActive(true);
    }
}
