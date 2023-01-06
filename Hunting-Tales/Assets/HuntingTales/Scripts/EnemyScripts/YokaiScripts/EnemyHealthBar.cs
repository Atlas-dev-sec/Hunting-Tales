using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider enemySlider;
    private int damageAmount;
    private float currentDamageAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        damageAmount = 50; // do not change this value...
        enemySlider.maxValue = damageAmount;
        enemySlider.value = 0;
        enemySlider.fillRect.gameObject.SetActive(false);
    }

    // method that controls the enemy's health bar slider UI...
    public void EnemyHealthBarSlider(float amount)
    {
        currentDamageAmount += amount;
        enemySlider.fillRect.gameObject.SetActive(true);
        enemySlider.value = currentDamageAmount;
        // if the current damage is greater or equal than damage amount set to (50) destroy the enemy yokai game object...
        if(currentDamageAmount >= damageAmount)
        {
            Destroy(gameObject, 0.1f);
            CaptureScript.canBeCapture = false;
        }
    }

}
