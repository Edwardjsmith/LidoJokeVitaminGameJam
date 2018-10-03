using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public int score;
    public int comboCount;
    public int lives;

	// Use this for initialization
	void Start () {
		
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
            score = (score+1) * comboCount;
        }
        comboCount++;
    }

    public void resetCombo()
    {
        comboCount = 0;
        lives--;
        if(lives<0)
        {
            // do end game
        }
    }
}
