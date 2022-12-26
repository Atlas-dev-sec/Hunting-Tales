using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DemonScript : MonoBehaviour
{
    public static float enemyLife;
    private float damage = 0.1f;
    private CaptureScript captureScript;
    private EnemyHealthBar enemyHealthBar;
    void Start()
    {
        captureScript = FindObjectOfType<CaptureScript>();
        enemyHealthBar = FindObjectOfType<EnemyHealthBar>(); 
        enemyLife = 50.0f;
    }

    void FixedUpdate() 
    {
        if (CaptureScript.isCapturing)
        {
            if (enemyLife >= 0)
                DamageEnemy();
                enemyHealthBar.EnemyHealthBarSlider(0.1f);
            if (enemyLife < 0)
                captureScript.DetachEnemy();
        }
    }
    private void DamageEnemy()
    {
        enemyLife -= damage;
    }
}
