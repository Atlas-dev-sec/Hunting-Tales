using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Cinemachine;

public class CaptureScript : MonoBehaviour
{
    public GameObject child;
    public Rigidbody playerRb;
    public Transform parent;
    public int speed = 10;
    public static bool isCapturing;
    public static bool canBeCapture;

    void Awake() 
    {
        isCapturing = false;    
    }
    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(canBeCapture);
        if (Input.GetKeyDown(KeyCode.X) && canBeCapture == true)
        {
            CaptureEnemy(parent);
            isCapturing = true;
        }

        if (isCapturing && Input.GetKeyDown(KeyCode.Z))
        {
            isCapturing = false;
            DetachEnemy();
        }

        if (DemonScript.enemyLife < 0)
            isCapturing = false;
       
        if (isCapturing)
            playerRb.AddForce(Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse);
    }

    public void CaptureEnemy(Transform newParent)
    {
        child.transform.SetParent(newParent);
        Vector3 pos = new Vector3(transform.position.x + 1.3f, child.transform.position.y, transform.position.z + 1.3f);
        child.transform.position = pos;    
    }

    public void DetachEnemy()
    {
        child.transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("DemonEnemy"))
        {
            canBeCapture = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("DemonEnemy"))
        {
            canBeCapture = false;
        }
    }
}
