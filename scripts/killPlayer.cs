using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour {

    public GameObject deathMenu;
    public GameObject gameAudio;
    public GameObject gameOverAudio;

    void Awake()
    {
        deathMenu.SetActive(false);
        gameAudio.SetActive(true);
        gameOverAudio.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "killbox")
        {
            triggerDeath();
        }
    }

    void triggerDeath()
    {
        Debug.Log("player_hit_killbox");
        Time.timeScale = 0;
        deathMenu.SetActive(true);
        gameAudio.SetActive(false);
        gameOverAudio.SetActive(true);
    }
}
