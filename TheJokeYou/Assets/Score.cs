using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public int score;
    public int comboCount;

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
    }
}
