﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {

    float speed = 100f;

	void Update ()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
