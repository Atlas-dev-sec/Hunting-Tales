using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject yokaiMisteryBox;
    //public GameObject misteryBox;
    /*
    Variables that sets the position of the mistery boxes these variables can be changed in order to be placed around the level...
    */
    public Vector3 pos1 ;// these can be changed
    public Vector3 pos2 ;// these can be changed
    public Vector3 pos3 ;// these can be changed
    /**/
    public int[] posArr = {0,1,2,3}; // these array is initialized to three because there are three position that can respawn the mistery boxes...
    // Start is called before the first frame update
    void Awake()
    {
        
        pos1 = new Vector3(24.2999992f,0.00999999978f,20.2000008f);
        pos2= new Vector3(31.1f,0.88f,-76.4f);
        pos3 = new Vector3(0.29f,0.61f,44.43f);
        RandomPositionObjectRespawn();
    }
    // method that instantiate the mistery boxes in three position setting a random position position for the yokai enemy...
    private void RandomPositionObjectRespawn()
    {
        int index = Random.Range(0, posArr.Length);
        if(index == 0)
        {
            Instantiate(yokaiMisteryBox, pos1, yokaiMisteryBox.transform.rotation);
          //  Instantiate(misteryBox, pos2, misteryBox.transform.rotation);
            //Instantiate(misteryBox, pos3, misteryBox.transform.rotation);

        } 
        else if (index == 1)
        {
            Instantiate(yokaiMisteryBox, pos2, yokaiMisteryBox.transform.rotation);
           // Instantiate(misteryBox, pos1, misteryBox.transform.rotation);
            //Instantiate(misteryBox, pos3, misteryBox.transform.rotation);
        }
        else
        {
            Instantiate(yokaiMisteryBox, pos3, yokaiMisteryBox.transform.rotation);
           // Instantiate(misteryBox, pos1, misteryBox.transform.rotation);
            //Instantiate(misteryBox, pos2, misteryBox.transform.rotation);
        }
    }
}
