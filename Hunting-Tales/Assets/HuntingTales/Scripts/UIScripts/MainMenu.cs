using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void LoadEasyLevel()
    {
        SceneManager.LoadScene("EasyLevel");
    }

    public void LoadMediumLevel()
    {
        SceneManager.LoadScene("MediumLevel");
    }

    public void LoadHardLevel()
    {
        SceneManager.LoadScene("HardLevel");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
