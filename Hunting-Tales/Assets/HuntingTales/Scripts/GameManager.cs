using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    
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

    private void CheckWinCondition()
    {
        if (player.GetComponent<CaptureScript>().enemyCaptured == true)
        {
            Debug.Log("GAME WON!!!");
            gameWon = true;
        }
    }

    private void CheckLoseCondition()
    {
        if (player.GetComponent<PlayerMovement>().currentHealth <= 0)
        {
            Debug.Log("GAMEOVER");
            gameOver = true;
            // in here put the logic to set the game over UI
        }
    }
}
