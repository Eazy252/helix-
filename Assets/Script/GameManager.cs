using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static bool gameOver;
    public static bool levelCompleted;

    public GameObject gameOverText; 
    public GameObject levelCompletedText;

   void Start()
    {
        gameOver = levelCompleted = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == true){ 
            Time.timeScale = 0;
            gameOverText.SetActive(true);
            if(Input.GetButtonDown("Fire1"))
            { 
                SceneManager.LoadScene("Level");
            }
        }

        if(levelCompleted == true){ 
            Time.timeScale = 0;
            levelCompletedText.SetActive(true);
            if(Input.GetButtonDown("Fire1"))
            { 
                SceneManager.LoadScene("Level");
            }
        }
    }
}
