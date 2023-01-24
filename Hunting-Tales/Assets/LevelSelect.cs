using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadOne()
    {
        Debug.Log("carga");
        SceneManager.LoadScene("Level");
    }
        public void LoadSecond()
    {
        SceneManager.LoadScene("Level3");
    }
        public void LoadThird()
    {
        SceneManager.LoadScene("Level2");
    }
        public void LoadFour()
    {
        SceneManager.LoadScene("Level4");
    }
}
