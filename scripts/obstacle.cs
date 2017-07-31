using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{

    public float maxRot = 60f;
    public float minRot = 0f;

    private float rotation = 0;

    void Start()
    {
        rotation = Random.Range(maxRot, minRot);

        transform.Rotate (rotation, 0, 0);
    }

}