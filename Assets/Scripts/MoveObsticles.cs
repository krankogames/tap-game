using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObsticles : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime, 0);
    }
}
