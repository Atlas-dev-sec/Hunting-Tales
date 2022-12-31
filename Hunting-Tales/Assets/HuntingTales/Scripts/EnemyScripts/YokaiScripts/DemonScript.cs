using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DemonScript : MonoBehaviour
{
    public static float enemyLife;
    private float damage = 0.1f;
    private CaptureScript captureScript;
    private EnemyHealthBar enemyHealthBar;
    public Rigidbody yokaiRb;
    public float speed;
    public GameObject playerTarget;
   
    void Start()
    {
        captureScript = FindObjectOfType<CaptureScript>();
        enemyHealthBar = FindObjectOfType<EnemyHealthBar>(); 
        enemyLife = 50.0f;
        playerTarget = GameObject.Find("Player");
    }

    void FixedUpdate() 
    {
        CaptureEnemy();
    }

    private void CaptureEnemy()
    {
        if (CaptureScript.isCapturing)
        {
            yokaiRb.AddForce(Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse);
            if (enemyLife >= 0)
                DamageEnemy();
                enemyHealthBar.EnemyHealthBarSlider(0.1f);
            if (enemyLife <= 0)
                captureScript.DetachEnemy();
        }else{
            transform.LookAt(playerTarget.transform);
        }
    }

    private void DamageEnemy()
    {
        enemyLife -= damage;
    }
}
