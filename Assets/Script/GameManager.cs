using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{

    public static bool gameOver;
    public static bool levelCompleted;
    public static int numberofPassedRings;
    public static bool isGameStarted = false;


    public static int currentLevelIndex;
    public TextMeshProUGUI currentLeveltext;
    public TextMeshProUGUI nextLeveltext; 
    public Slider gameProgressSlider;
    

    public static bool mute = false;

    public  GameObject gamePlayPanel;
    public  GameObject startmenuPanel;

    public GameObject gameOverText; 
    public GameObject levelCompletedText;

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
        isGameStarted = gameOver = levelCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {   
        int progress = numberofPassedRings * 100 / FindObjectOfType<HelixManager>().numberOfRings;
        gameProgressSlider.value = progress;

        if(Input.GetMouseButtonDown(0) && !isGameStarted){ 
            if(EventSystem.current.IsPointerOverGameObject())
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
