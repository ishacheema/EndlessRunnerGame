using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;
    public Text finalScoreText;

    public float scoreCount;
    public float highScoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;

    public bool shouldDouble;
    public bool shouldTriple;
    public bool shouldMultiply;


	// Use this for initialization


    void Update () {

        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if(scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
        }

        scoreText.text = "Score: " + Mathf.Round (scoreCount);
        highScoreText.text = "High Score: " + Mathf.Round (highScoreCount);
	}

    public void DeathScore()
    {
        finalScoreText.text = "Final Score: " + Mathf.Round (scoreCount);
    }

    public void AddScore(int pointsToAdd)
    {
        if(shouldDouble)
        {
            pointsToAdd = pointsToAdd * 2;            
        }

        if (shouldTriple)
        {
            pointsToAdd = pointsToAdd * 3;
        }

        if(shouldMultiply)
        {
            pointsToAdd = pointsToAdd * 100;
        }

        scoreCount += pointsToAdd;
    }


}
