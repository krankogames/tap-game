using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    public float startSpeed = 3f;
    public float border = 2.45f;
    private readonly Vector3 move=new Vector3(0, 2f, 0);
    private static bool moveleft = true;
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.05f;
    public GameObject menu;
    private float timer;
    private float speed;
    public GameObject gameOver;
    private bool DEAD;

    public TMP_Text scoreTxt;
    private int score;
    private float start;
    public Spawner spawner;
    public float interval = 20;
    public UIManager ui;


    private void Awake()
    {
        score = 0;
        timer = 0;
        DEAD = false;
        scoreTxt.text = score.ToString();
        start = transform.position.y;
    }

    void Update()
    {
        if (DEAD)
            return;

        timer += Time.deltaTime;
        speed = startSpeed + timer * 0.1f;

        if (transform.position.y - start > interval)
        {
            spawner.SpawnObstacle(new Vector3(transform.position.x, transform.position.y + 30, transform.position.z));
            start = transform.position.y;
            interval -= 0.1f;
        }

        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.anyKey)
        {
            Vector3 target = transform.position + move;
            transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothTime);
        }
        else if (transform.position.x > -border && moveleft)
        {
            transform.position -= new Vector3(Time.deltaTime * speed, -Time.deltaTime*speed/5, 0);
        }
        else
        {
            moveleft = false;
            transform.position += new Vector3(Time.deltaTime * speed, Time.deltaTime*speed/5, 0);

            if (transform.position.x > border)
                moveleft = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "score")
        {
            score++;
            scoreTxt.text = score.ToString();
        }
        else
        {
            StartCoroutine(GameOver());
        }
    }

    private IEnumerator GameOver()
    {
        DEAD = true;
        gameOver.SetActive(true);
        yield return new WaitForSeconds(1F);
        ui.OnEndGame();
    }
}
