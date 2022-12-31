using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonDash : MonoBehaviour
{
    //PlayerController moveScript;
    PlayerMovement moveScript;
    public float dashTime;
    // Start is called before the first frame update
    void Start()
    {
        //moveScript = GetComponent<PlayerController>();
        moveScript = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;

        while(Time.time < startTime + dashTime)
        {
            moveScript.DashPlayer();
            yield return null;
        }    
        moveScript.dashParticle.Stop();
    }
}
