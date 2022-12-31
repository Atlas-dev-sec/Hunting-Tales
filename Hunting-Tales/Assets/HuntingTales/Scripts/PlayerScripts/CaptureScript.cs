using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Cinemachine;

public class CaptureScript : MonoBehaviour
{
    public GameObject child;
    public Transform parent;
    public int speed = 10;
    public static bool isCapturing;
    public static bool canBeCapture;
    public bool enemyCaptured;
    public float t;
    public Transform target;
    void Awake() 
    {
        isCapturing = false;   
    }

    void Start()
    {
        child = GameObject.FindWithTag("DemonEnemy");
    }
    void FixedUpdate()
    {
        if (child == null)
        {
            Debug.Log("yokai enemy destroyed");
            enemyCaptured = true;
        }
        if (target == null){
            target = parent;
        }

        Vector3 playerPos = transform.position; 
        Vector3 targetPos = target.position;
    
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

        if (DemonScript.enemyLife < 0){
            isCapturing = false;
        }
       
        if (isCapturing){
            transform.position = Vector3.Lerp(playerPos, targetPos , t);
        }
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
