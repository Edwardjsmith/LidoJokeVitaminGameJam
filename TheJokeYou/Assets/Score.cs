using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    public int score;
    public int comboCount;
    public int totalHits;
    public int lives;

    public GameObject highScoreList;
    public Text scoreText;
    public Text livesText;
    public Text comboText;
    public Text totalText;
    // Use this for initialization
    void Start () {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        livesText = GameObject.Find("LivesText").GetComponent<Text>();
        comboText = GameObject.Find("ComboText").GetComponent<Text>();
        totalText = GameObject.Find("TotalText").GetComponent<Text>();
        highScoreList = FindObjectOfType<ScoreList>().gameObject;
        lives = 3;

        scoreText.text = score.ToString();
        comboText.text = comboCount.ToString();
        totalText.text = totalHits.ToString();
        livesText.text = lives.ToString();
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
        totalHits++;
        scoreText.text = score.ToString();
        comboText.text = comboCount.ToString();
        totalText.text = totalHits.ToString();
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
            SceneManager.LoadScene("Menu");
        }
    }
}
