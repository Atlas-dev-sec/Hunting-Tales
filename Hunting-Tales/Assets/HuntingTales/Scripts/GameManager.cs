using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private GameObject pauseScreen;
    public bool gameOver = true;
    public bool gameWon;
    
    void Awake() 
    {
        pauseScreen = GameObject.FindWithTag("Pause");
    }
    void Start()
    {
        //player = GameObject.Find("Player");
        pauseScreen.SetActive(true);
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
            pauseScreen.SetActive(false);
        }
    }

    // method that checks for the Lose Condition...
    private void CheckLoseCondition()
    {  
        if (player.GetComponent<PlayerMovement>().currentHealth <= 0)
        {
            gameOver = true;
            pauseScreen.SetActive(false);
        }

    }
}
