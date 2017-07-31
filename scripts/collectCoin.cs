using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectCoin : MonoBehaviour {

    public int coinValue = 1;

    private int scoreInt = 0;

    public Text scoreTxt;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "coin")
        {
            scoreInt = scoreInt + coinValue;
            scoreTxt.text = scoreInt.ToString();

            Destroy(other.gameObject);
        }
    }
}
