using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveCharge : MonoBehaviour
{
    public BulletCount currentBullets;
    
    // Start is called before the first frame update
    void Start()
    {
        currentBullets = FindObjectOfType<BulletCount>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag.Equals("Player"))
        {
            
            gameObject.SetActive(false);
            currentBullets.amountBullets = currentBullets.amountBullets + 5;
            
         
            
            Invoke("Charge",30);
            
        }
    }
    public void Charge(){
        gameObject.SetActive(true);
        
    }


}
