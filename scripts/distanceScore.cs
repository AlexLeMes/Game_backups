using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class distanceScore : MonoBehaviour {

    public Text scoreTxt;
    public Text highScoreTxt;

    float highScore = 0;

    float dis = 0;
    float score = 0;

    public float speedIncrease = 2f;
    public float disToIncSpeed = 150f;

    public float timeSpeedIncrease = 0.005f;

    void Start()
    {
        highScoreTxt.text = PlayerPrefs.GetFloat("highScore", score).ToString();
        Time.timeScale = 1;
    }

    void Update()
    {
        dis = Time.timeSinceLevelLoad * speedIncrease;

        if(dis > disToIncSpeed)
        {
            Time.timeScale = Time.timeScale + timeSpeedIncrease;
            disToIncSpeed = disToIncSpeed * 2;

            Debug.Log(Time.timeScale + " = SPEED");
        }

        score = Mathf.Ceil(dis);

        scoreTxt.text = score.ToString() + "M";

        highScore = score;
        if (score > PlayerPrefs.GetFloat("highScore", 0))
        {
            PlayerPrefs.SetFloat("highScore", highScore);
            highScoreTxt.text = score.ToString() + "M";
        }
    }
}
