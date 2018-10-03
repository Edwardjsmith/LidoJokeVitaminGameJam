using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerCollision : MonoBehaviour {

    Score score;
    float timer;

    private void Start()
    {
        score = GetComponent<Score>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Joke")
        {
            if (timer <= 0)
            {
                score.ScoreIncrement();
                timer = 0.5f;
            }
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

