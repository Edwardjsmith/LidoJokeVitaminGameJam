using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jokeCollision : MonoBehaviour
{
    Joke joke;
    Score score;

    private void Start()
    {
        joke = GetComponent<Joke>();
        score = GameObject.Find("player").GetComponent<Score>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "trigger")
        {
            score.resetCombo();
            joke.ResetSpeed();
        }

        joke.ResetPosition();
    }
}
