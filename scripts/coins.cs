using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour {

    public float speed = 5f;

    public int destroyTime = 25;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

}
