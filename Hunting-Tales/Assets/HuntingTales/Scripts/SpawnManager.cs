using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector3 pos1 = new Vector3(1.15802145f, 2.03999996f, 13.146656f);// Vector3(1.15802145,2.03999996,13.146656)
    public Vector3 pos2= new Vector3(-6.84000015f, 2.03999996f, 3.50999999f);
    public Vector3 pos3 = new Vector3(10.1999998f, 2.03999996f, 3.50999999f);
    public int[] posArr = {0,1,2,3};
    // Start is called before the first frame update
    void Awake()
    {
        int index = Random.Range(0, posArr.Length);
        if(index == 0)
        {
            Instantiate(objectToSpawn, pos1, objectToSpawn.transform.rotation);
        } 
        else if (index == 1)
        {
            Instantiate(objectToSpawn, pos2, objectToSpawn.transform.rotation);
        }
        else
        {
            Instantiate(objectToSpawn, pos3, objectToSpawn.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
