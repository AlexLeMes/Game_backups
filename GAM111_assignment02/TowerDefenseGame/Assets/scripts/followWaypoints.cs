using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followWaypoints : MonoBehaviour {

    public waypointSystem myPath;

    public float speed = 1f;

    int currentPositionIndex;


	void Start () {
        currentPositionIndex = 0;
	}

	void Update ()
    {

        transform.position = Vector3.MoveTowards(transform.position, myPath.positions[currentPositionIndex], speed * Time.deltaTime);

        if(transform.position == myPath.positions[currentPositionIndex])
        {
            currentPositionIndex++;
            if(currentPositionIndex == myPath.positions.Length)
            {
                currentPositionIndex = 0;
            }
        }
	}
}
