using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerCollision : MonoBehaviour {

    Score score;

    private void Start()
    {
        score = GetComponent<Score>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Joke")
        {
            score.ScoreIncrement();
        }

        if(collision.name == "start")
        {
            sceneChange(1);
        }
    }

    void sceneChange(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}

