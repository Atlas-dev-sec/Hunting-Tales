using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip winSound;
    public GameObject gameManager;
    public GameObject player;
    public GameObject winScreen;
    public string activeScene;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        //player = GameObject.Find("Player");
        audioSource.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetComponent<GameManager>().gameWon == true)
        {
            winScreen.SetActive(true);
            StartCoroutine(PlayWinSound());
            Time.timeScale = 0.0f;
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        player.GetComponent<PlayerMovement>().currentHealth = player.GetComponent<PlayerMovement>().maxHealth;
        player.GetComponent<CaptureScript>().enemyCaptured = false;
        gameManager.GetComponent<GameManager>().gameWon = false;
        SceneManager.LoadScene(activeScene);

    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1.0f;
        player.GetComponent<PlayerMovement>().currentHealth = player.GetComponent<PlayerMovement>().maxHealth;
        player.GetComponent<CaptureScript>().enemyCaptured = false;
        gameManager.GetComponent<GameManager>().gameWon = false;
        SceneManager.LoadScene("LevelSelectScreen");
    }

    public IEnumerator PlayWinSound()
    {
        audioSource.PlayOneShot(winSound);
        yield return new WaitForSecondsRealtime(0.2f);
        audioSource.enabled = false;
    }
}
