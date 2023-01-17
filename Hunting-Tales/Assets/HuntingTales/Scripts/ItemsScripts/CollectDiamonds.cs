using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectDiamonds : MonoBehaviour
{

    [SerializeField] private AudioClip collectSoundEffect;
    
    
        private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player")){
            SoundController.Instance.ExecuteSound(collectSoundEffect);
           
            Destroy(gameObject);

        }
       
    }


}
