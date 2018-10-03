using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {

    public ScrollRect ScrollView;
    public GameObject ScoreContent;
    public GameObject HighScorePrefab;

    private int highscore;

    void Start ()
    {
        for (int i = 0; i < ScoreList.length; i++)
        {
            highscore = ScoreList[count];

            GameObject HighScoreObj = Instantiate(HighScorePrefab);
            HighScoreObj.transform.SetParent(ScoreContent.transform, false);
            HighScoreObj.transform.Find("Score").gameObject.GetComponent<Text>().text = highscore.ToString();
        }
    }
}
