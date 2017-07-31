using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

    private Rigidbody playerRigBod;

    public int upForce = 500;

    void Awake ()
    {
        playerRigBod = gameObject.GetComponent<Rigidbody>();
	}

	void Update ()
    {
        //transform.Translate(moveSpeed * Time.deltaTime, 0, 0);

        if(Input.GetKey(KeyCode.Space))
        {
            playerRigBod.AddForce(0, upForce * Time.deltaTime, 0);
        }

        /*
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerRigBod.velocity = new Vector3(0, upForce / 1.5f * Time.deltaTime, 0);
        }
        

        if(Time.time > timeDiff)
        {
            moveSpeed = moveSpeed + speedIncrease;
            Debug.Log("PLAYER_SPEED = " + moveSpeed);
            timeDiff += timeDiff;
        }
        */

    }
}
