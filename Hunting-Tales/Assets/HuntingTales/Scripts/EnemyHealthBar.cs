using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider enemySlider;
    public int damageAmount;
    private float currentDamageAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemySlider.maxValue = damageAmount;
        enemySlider.value = 0;
        enemySlider.fillRect.gameObject.SetActive(false);
    }

    public void EnemyHealthBarSlider(float amount)
    {
        currentDamageAmount += amount;
        enemySlider.fillRect.gameObject.SetActive(true);
        enemySlider.value = currentDamageAmount;
        if(currentDamageAmount >= damageAmount)
        {
            Destroy(gameObject, 0.1f);
            CaptureScript.canBeCapture = false;
        }
    }

}
