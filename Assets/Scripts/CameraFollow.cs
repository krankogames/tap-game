
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private float smoothTime = 0.05F;
    private Vector3 velocity = Vector3.zero;
    public GameObject player;

    void Update()
    {

        Vector3 targetPosition = player.transform.position + new Vector3(0, 1, -10);
        targetPosition.x = 0;
        //Vector3 targetPositionBackground = background.transform.position + new Vector3(2, 2, 0);
        //transform.position = targetPosition;
        transform.position= Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }


}
