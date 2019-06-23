using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public TextMesh scoreText;
    public TextMesh highScoreText;
    public TextMesh deathScore;

    public float scoreCount;
    public float highScoreCount;

    public bool scoreIncreasing;


    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetFloat("HighScore") != null)
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        scoreText.text = "" + Mathf.Round(scoreCount);

    }

    public void AddScore(int point)
    {
        scoreCount += point;
    }
}
