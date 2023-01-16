using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyYokayBox : MonoBehaviour
{
    public GameObject fragments;
    //public GameObject diamond;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other){
        if(other.gameObject.tag.Equals("Weapon")){
            Instantiate(fragments, transform.position, Quaternion.identity);
            //Instantiate(diamond, transform.position , Quaternion.identity);
            this.gameObject.SetActive(false);
            //StartCoroutine(DestroyFragments());
        }
    }

    /*public IEnumerator DestroyFragments(){
        for(int i = 0; i < ; i++) {
            fragments.SetActive(false);
        }
        yield return new WaitForSeconds(1f);
    }*/
}
