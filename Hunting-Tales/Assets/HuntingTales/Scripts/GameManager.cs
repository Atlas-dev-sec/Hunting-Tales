using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    public bool gameOver;
    public bool gameWon;
    
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        CheckWinCondition();
        CheckLoseCondition();
    }

    // methods that checks for the win condition...
    private void CheckWinCondition()
    { 
        if (player.GetComponent<CaptureScript>().enemyCaptured == true)
        {
            gameWon = true;
        }
    }

    // method that checks for the Lose Condition...
    private void CheckLoseCondition()
    {  
        if (player.GetComponent<PlayerMovement>().currentHealth <= 0)
        {
            gameOver = true;
        }
    }
}
