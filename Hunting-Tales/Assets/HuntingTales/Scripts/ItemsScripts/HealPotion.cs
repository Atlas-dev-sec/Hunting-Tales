using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : MonoBehaviour
{
    public PlayerMovement player;
    public HealthBar healthBar;
    private float healingFactor = 10.0f;
    void OnTriggerEnter(Collider other) 
    {
        
        if(other.CompareTag("Player"))
        {
            if (player.currentHealth >= player.maxHealth)
            {
                Destroy(gameObject);
            }
            else if (player.currentHealth >= 90.0f && player.currentHealth <= 99.0f)
            {
                player.currentHealth += player.maxHealth - player.currentHealth;
                healthBar.SetHealth(player.currentHealth);
                Destroy(gameObject);
            }
            else
            {
                player.currentHealth += healingFactor;
                healthBar.SetHealth(player.currentHealth);
                Destroy(gameObject);
            }
            
            
        }    
    }
}
