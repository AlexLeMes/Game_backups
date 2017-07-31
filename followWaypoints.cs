using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followWaypoints : MonoBehaviour {

    public waypointSystem myPath;

    public float speed = 1f;

    int currentPositionIndex;

	// Use this for initialization
	void Start () {
        currentPositionIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, myPath.positions[currentPositionIndex], speed);

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
