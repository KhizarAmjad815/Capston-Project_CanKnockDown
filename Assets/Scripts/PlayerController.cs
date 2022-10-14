using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject ballPrefab;
    public int numOfBalls;

    // Start is called before the first frame update
    void Start()
    {
        numOfBalls = Random.Range(3, 6);
        GameManager.gameManager.UpdateBalls(numOfBalls);
        Debug.Log("You have " + numOfBalls + " balls to throw");
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.S) && FindObjectsOfType<Ball>().Length == 0 && numOfBalls > 0)
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                Instantiate(ballPrefab, pos, ballPrefab.transform.rotation);
                numOfBalls--;

                GameManager.gameManager.UpdateBalls(numOfBalls);
                Debug.Log(numOfBalls + " balls remaining");
            }
            if (FindObjectsOfType<DestroyColaCan>().Length > 0)
            {
                if (numOfBalls <= 0)
                {
                    if (FindObjectsOfType<Ball>().Length == 0)
                    {
                        GameManager.isGameOver = true;
                        GameManager.gameManager.AddScore(0);
                        Debug.Log("GAME OVER!!");
                    }
                }
            }
            else
            {
                GameManager.gameManager.isLevelCompleted = true;
                GameManager.gameManager.PlayNextLevel();
                numOfBalls = Random.Range(3, 6);
                Debug.Log("Level Completed!");
            }
        }
    }
}
