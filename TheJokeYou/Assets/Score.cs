using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int score;
    public int comboCount;
    public int lives;

    public GameObject highScoreList;
    public Text scoreText;
    public Text livesText;
    // Use this for initialization
    void Start () {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        livesText = GameObject.Find("LivesText").GetComponent<Text>();
        highScoreList = FindObjectOfType<ScoreList>().gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ScoreIncrement()
    {
        if(comboCount<=0)
        {
            score++;
        }
        else
        {
            score = (score+1) + comboCount;
        }
        comboCount++;
        scoreText.text = score.ToString();
    }

    public void resetCombo()
    {
        comboCount = 0;
        lives--;
        livesText.text = lives.ToString();
        if(lives<0)
        {
            // do end game
            highScoreList.GetComponent<ScoreList>().add(score);
            score = 0;
        }
    }
}
