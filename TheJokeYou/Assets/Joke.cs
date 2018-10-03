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

    private float moveTimer;
    private float baseSpeed;

    void Start()
    {
        baseSpeed = speed;
        ResetPosition();
    }

	public void ResetPosition()
    {
        transform.position = new Vector3(startX, Random.Range(minY, maxY), 0);
        moveTimer = timeToNextJoke;
        speed = Mathf.Clamp(speed + speedIncrease, 0, maxSpeed);
    }

    public void ResetSpeed()
    {
        speed = baseSpeed;
    }

    void Update()
    {
        moveTimer -= Time.deltaTime;
        if (moveTimer <= 0)
        {
            transform.Translate(new Vector3(-speed, 0, 0));
            if (transform.position.x <= endX)
            {
                ResetPosition();
            }
        }
    }
}
