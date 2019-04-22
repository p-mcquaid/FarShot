using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {

    public Text scoreText, highScoreText;
    public float scoreCount, highScoreCount, pointsPer;
    public bool isScoring;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (isScoring)
        {
            scoreCount += pointsPer * Time.deltaTime;
        }

        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        scoreText.text = "Distance: " + Mathf.Round(scoreCount) + "m";
        highScoreText.text = "Farthest Distance: " + Mathf.Round(highScoreCount) + "m";
	}
}
