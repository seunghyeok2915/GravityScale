using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float speed;

    public float scorePoint;
    public Text text;
    public Player player;
    void Start()
    {
        StartCoroutine(Speed());
        if (instance == null) instance = this;
    }
    private void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
        if (Time.timeScale > 0.9f)
        {
            if (player.pScore)
            {
                scorePoint += 50;
                player.pScore = false;
            }
            text.text = "" + scorePoint;
        }
    }


    // Update is called once per frame\

    IEnumerator Speed()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            scorePoint += 5;
            if (speed < 15f)
            {
                speed += 0.015f;
            }
        }
    }
}
