using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMap : MonoBehaviour
{
    [SerializeField] Transform[] levels;
    [SerializeField] GameObject[] levelsMap;
    Camera cam;
    int currentIndex = 0;
    [SerializeField] float speed = .5f;

    int unlockedLevelsNumber;


   


    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        if(!PlayerPrefs.HasKey("Unlocked")) {
            PlayerPrefs.SetInt("Unlocked",1);
            //PlayerPrefs.DeleteKey("levelsUnlocked");
            
        }
        unlockedLevelsNumber = PlayerPrefs.GetInt("Unlocked");
        
        for(int i = 0; i < levelsMap.Length ; i++) {
            
            //Debug.Log(unlockedLevelsNumber);
            //Debug.Log(unlockedLevelsNumber);
            //Debug.Log("espacio");
                levelsMap[i].transform.GetChild(3).gameObject.SetActive(true);
                levelsMap[i].transform.GetChild(4).gameObject.SetActive(true);
  
        }

    }

    private void Update() {
          
               unlockedLevelsNumber = PlayerPrefs.GetInt("Unlocked");
            for(int i = 0; i < unlockedLevelsNumber; i++) {
        
                    Debug.Log(i);
                levelsMap[i].transform.GetChild(3).gameObject.SetActive(false);
                levelsMap[i].transform.GetChild(4).gameObject.SetActive(false);

            }
       // Debug.Log("update");
       // Debug.Log(unlockedLevelsNumber);


    }
    // Update is called once per frame
    void LateUpdate()
    {
        cam.transform.position = Vector2.Lerp(cam.transform.position, levels[currentIndex].position, speed);


        
    }

    public void  ClickRight(){
        Move(1); //1: right  -1:left
    }
    public void  ClickLeft(){
        Move(-1); //1: right  -1:left
    }
    public void Click(){}
    void Move(int dir){
    currentIndex += dir;
    currentIndex = (currentIndex < 0 ) ? levels.Length -1 : currentIndex;
    currentIndex = (currentIndex >= levels.Length)? 0 : currentIndex;
    }
}
//> <