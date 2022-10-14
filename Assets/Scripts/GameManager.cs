using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    private int score;
    public static bool isGameOver;

    public TMP_Text scoreText;
    public TMP_Text levelText;
    public TMP_Text remainBallsText;

    public GameObject[] levelPrefabs;
    private int levelCount;
    public bool isLevelCompleted;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
    }

    public void AddScore(int newScore)
    {
        if (newScore >= 0)
        {
            score += newScore;
        }
        if (isGameOver)
        {
            scoreText.text = "GAME OVER!";
        }
        else
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void UpdateBalls(int ball)
    {
        if (ball >= 0)
        {
            remainBallsText.text = "Balls: " + ball.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        levelCount = 0;
        Vector3 pos = new Vector3(0, 9f, -6.5f);
        Instantiate(levelPrefabs[levelCount], pos, levelPrefabs[levelCount].transform.rotation);
        isLevelCompleted = false;
        isGameOver = false;
        score = 0;
        levelText.text = "Level: " + (levelCount + 1);
    }
    
    public void PlayNextLevel()
    {
        if (isLevelCompleted)
        {
            levelCount += 1;
            Vector3 pos = new Vector3(0, 9f, -6.5f);
            Instantiate(levelPrefabs[levelCount], pos, levelPrefabs[levelCount].transform.rotation);
            levelText.text = "Level: " + (levelCount + 1);
            isLevelCompleted = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
