using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{

    public static bool gameOver, levelCompleted;
  
    public static int numberofPassedRings, currentLevelIndex;
    public static bool isGameStarted = false;

    public static int score = 0;

    public TextMeshProUGUI currentLeveltext, nextLeveltext, scoreText, highScoreText;
   
    public Slider gameProgressSlider;
    

    public static bool mute = false;

    public  GameObject gamePlayPanel;
     public  GameObject startmenuPanel;
      public  GameObject gameOverText;
       public  GameObject levelCompletedText;

    private void Awake() {
        currentLevelIndex = PlayerPrefs.GetInt("currentLevelIndex", 0);

    }
   void Start()
    {  
        currentLeveltext.text = currentLevelIndex.ToString();
         nextLeveltext.text = (currentLevelIndex +1).ToString();
        gameOver = levelCompleted = false;
        Time.timeScale = 1;
        numberofPassedRings =0;
        highScoreText.text = "High Score\n" + PlayerPrefs.GetInt("HighScore",0);
        isGameStarted = gameOver = levelCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {   
        int progress = numberofPassedRings * 100 / FindObjectOfType<HelixManager>().numberOfRings;
        gameProgressSlider.value = progress;

        scoreText.text = score.ToString();


        //Start Level
        //(Input.GetMouseButtonDown(0)  && !isGameStarted) for PC 
        
        if
             (Input.GetMouseButtonDown(0)  && !isGameStarted)
            //    ( 
            //         (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            //               ) )
                
        { 
            if(EventSystem.current.IsPointerOverGameObject()) // (Input.GetTouch(0).fingerId) for mobile 
            return;
            isGameStarted = true;
            gamePlayPanel.SetActive(true);
            startmenuPanel.SetActive(false);
        }

        if(gameOver == true){ 
            Time.timeScale = 0;
            gameOverText.SetActive(true);
            if(Input.GetButtonDown("Fire1"))
            {  
                if(score >  PlayerPrefs.GetInt("HighScore",0)){ 
                    PlayerPrefs.SetInt("HighScore", score);
                }
                 score =0;
                SceneManager.LoadScene("Level");
            }
        }

        if(levelCompleted == true){ 
            Time.timeScale = 0;
            levelCompletedText.SetActive(true);
            if(Input.GetButtonDown("Fire1"))
            {  PlayerPrefs.SetInt("currentLevelIndex",currentLevelIndex+1);
                SceneManager.LoadScene("Level");
            }
        }
    }
}
