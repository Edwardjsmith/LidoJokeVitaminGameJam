using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public TextAsset jokes;

    private float moveTimer;
    private float warningTimer;
    private float startTimer;
    private float baseSpeed;
    private Score score;
    private TextMesh textMesh;
    private float textWidth;
    private string[] jokeList;
    private string prevJoke;

    void Start()
    {
        score = FindObjectOfType<Score>();
        textMesh = GetComponent<TextMesh>();
        baseSpeed = speed;
        startTimer = timeToStart;
        jokeList = jokes.text.Split('\n');
        ResetPosition();
    }

	public void ResetPosition()
    {
        if (jokes)
        {
            string nextJoke = jokeList[Random.Range(0, jokeList.Length)];
            while (nextJoke == prevJoke)
            {
                nextJoke = jokeList[Random.Range(0, jokeList.Length)];
            }
            textMesh.text = "<-" + nextJoke + "--";
            prevJoke = nextJoke;
        }
        transform.position = new Vector3(startX, Random.Range(minY, maxY), 0);
        moveTimer = timeToNextJoke;
        warningTimer = warningTime;
        warning.SetActive(true);
        speed = Mathf.Clamp(speed + speedIncrease, 0, maxSpeed);

        float width = 0;
        foreach(char symbol in textMesh.text)
        {
            CharacterInfo info;
            if (textMesh.font.GetCharacterInfo(symbol, out info, textMesh.fontSize, textMesh.fontStyle))
            {
                width += info.advance;
            }
        }

        textWidth = width * textMesh.characterSize * textMesh.transform.lossyScale.x * 0.1f;
        GetComponent<BoxCollider2D>().size = new Vector2(textWidth * 10, 10);
        GetComponent<BoxCollider2D>().offset = new Vector2(textWidth * 5, 0);
    }

    public void ResetSpeed()
    {
        speed = baseSpeed;
        if (score) score.resetCombo();
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
                    if (transform.position.x <= endX - textWidth)
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
