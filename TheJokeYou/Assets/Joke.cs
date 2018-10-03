using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joke : MonoBehaviour {

    public float startX;
    public float endX;
    public float maxY;
    public float minY;
    public float speed;
    public float speedIncrease;
    public float maxSpeed;
    public float timeToNextJoke;
    public float warningTime;
    public float timeToStart;
    public GameObject warning;

    private float moveTimer;
    private float warningTimer;
    private float startTimer;
    private float baseSpeed;

    void Start()
    {
        baseSpeed = speed;
        startTimer = timeToStart;
        ResetPosition();
    }

	public void ResetPosition()
    {
        transform.position = new Vector3(startX, Random.Range(minY, maxY), 0);
        moveTimer = timeToNextJoke;
        warningTimer = warningTime;
        warning.SetActive(true);
        speed = Mathf.Clamp(speed + speedIncrease, 0, maxSpeed);
    }

    public void ResetSpeed()
    {
        speed = baseSpeed;
    }

    void Update()
    {
        startTimer -= Time.deltaTime;
        if (startTimer <= 0)
        {
            moveTimer -= Time.deltaTime;
            warningTimer -= Time.deltaTime;
            if (moveTimer <= 0)
            {
                if (warningTimer <= 0)
                {
                    warning.SetActive(false);
                    transform.Translate(new Vector3(-speed, 0, 0));
                    if (transform.position.x <= endX)
                    {
                        ResetPosition();
                    }
                }
                else if (Time.frameCount % 4 == 0)
                {
                    warning.SetActive(!warning.activeInHierarchy);
                }
            }
        }
        else
        {
            warning.SetActive(false);
        }
    }
}
