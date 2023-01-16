using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisteryBox : MonoBehaviour
{
    // if player collides with mistery box destroy the game object...
    private void OnCollisionEnter(Collision other) {
       if(other.gameObject.tag.Equals("Player") ){
            //Destroy(this.gameObject);
        } 
    }
}
