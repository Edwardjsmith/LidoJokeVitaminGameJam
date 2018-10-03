using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {

    public ScrollRect ScrollView;
    public GameObject ScoreContent;
    public GameObject HighScorePrefab;

    ScoreList score;

    private int highscore;

    void Start ()
    {
        score = FindObjectOfType<ScoreList>();


        for (int i = 0; i < score.scoreList.Count; i++)
        {
            highscore = score.scoreList[i];

            GameObject HighScoreObj = Instantiate(HighScorePrefab);
            HighScoreObj.transform.SetParent(ScoreContent.transform, false);
            HighScoreObj.transform.Find("Score").gameObject.GetComponent<Text>().text = highscore.ToString();
        }
    }
}
