using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour {

    public float speed = 5f;

    public float xPos;
    public float yPos;
    public float zPos;

    public float resetDistance = 200;

    void Update()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime);

        if (transform.position.z <= -resetDistance)
        {
            transform.position = new Vector3(xPos, yPos, zPos);
        }
    }
}
