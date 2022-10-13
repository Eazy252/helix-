using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{

    public GameObject [] players;
    private int selectedPlayer = 0;


 void Start()
    {  
        foreach (GameObject  thePlayer in players)
        { thePlayer.SetActive(false);
            
        } 
        players[selectedPlayer].SetActive(true);
        
    }

    public void ChangePlayer(int newPlayer){ 

        players[selectedPlayer].SetActive(false);
        players[newPlayer].SetActive(true);
        selectedPlayer = newPlayer;
    }
}
