using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectDiamonds : MonoBehaviour
{

    [SerializeField] private AudioSource collectSoundEffect;
    private bool unActive = false;
    

private void Update() {
                if (unActive)
        {
           
        }
}

        private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player")){
            collectSoundEffect.Play();
            StartCoroutine(HitSoundCoroutine());
            //this.gameObject.SetActive(false);
            


            StartCoroutine(HitSoundCoroutine());
            //this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
       
    }

     private IEnumerator HitSoundCoroutine()
    {
        
        yield return new WaitForSeconds(0.4f);
        //collectSoundEffect.Play();
        this.gameObject.SetActive(false);

    }
}
