using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject player;
    public GameObject gameOverScreen;
    public string activeScene;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetComponent<GameManager>().gameOver == true)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        player.GetComponent<PlayerMovement>().currentHealth = player.GetComponent<PlayerMovement>().maxHealth;
        gameManager.GetComponent<GameManager>().gameOver = false;
        SceneManager.LoadScene(activeScene);

    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1.0f;
        player.GetComponent<PlayerMovement>().currentHealth = player.GetComponent<PlayerMovement>().maxHealth;
        gameManager.GetComponent<GameManager>().gameOver = false;
        SceneManager.LoadScene("MainMenu");
    }
}
