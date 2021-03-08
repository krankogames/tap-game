using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    public float startSpeed = 3f;
    public float border = 2.45f;
    private readonly Vector3 move=new Vector3(0, 2.5f, 0);
    private static bool moveleft = true;
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.05f;
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

        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.anyKey)
        {
            Vector3 target = transform.position + move;
            transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothTime);
        }
        else if (transform.position.x > -border && moveleft)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0;
        menu.SetActive(true);
    }
}
