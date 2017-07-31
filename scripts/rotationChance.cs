using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationChance : MonoBehaviour {

    float speed = 55f;

    bool rotate = false;

    void Awake()
    {
        int i = Random.Range(0, 10);
        Debug.Log(i + " =rotate_Chance");

        if(i >= 5)
        {
            rotate = true;
        }
        else
        {
            rotate = false;
        }
    }

    void Update ()
    {
		if(rotate == true)
        {
            transform.Rotate(speed * Time.deltaTime, 0, 0);
        }
	}
}
