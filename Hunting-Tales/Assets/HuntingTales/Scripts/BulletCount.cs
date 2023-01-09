using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCount : MonoBehaviour
{
    public GameObject objectToFind;
    // Start is called before the first frame update
    public int amountBullets = 3;

    private void Start()
    {
        objectToFind = GameObject.FindGameObjectWithTag("Bottle");
       
    }

    private void Update()
    {
        if (amountBullets > 0)
        {
            objectToFind.SetActive(true);
        }
        else
        {
            objectToFind.SetActive(false);
        }
    }

}
