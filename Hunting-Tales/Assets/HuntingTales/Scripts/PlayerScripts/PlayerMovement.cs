using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRb;
    private float moveSpeed = 2;
    private float rotationSpeed = 4;
    private float runningSpeed;
    private float vaxis, haxis;
    private Vector3 movement;
    private float dashSpeed;
    public ParticleSystem dashParticle;
    public float maxHealth = 100.0f;
    public float currentHealth;
    private float maxDash;
    private float currentDash;
    private float jumpForce;
    public HealthBar healthBar;
    public DashBar dashBar;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        dashSpeed = 75.0f;
        jumpForce = 10.0f;
        // initializing the health bar variables
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        // initializing the cool down bar variables
        maxDash = 3;
        currentDash = maxDash;
        dashBar.SetMaxDash(maxDash);
    }


    void FixedUpdate()
    {
        /*  Controller Mappings */
        vaxis = Input.GetAxis("Vertical");
        haxis = Input.GetAxis("Horizontal");
    
        //Simplified...
        runningSpeed = vaxis;

        movement = new Vector3(0, 0f, runningSpeed * 8);// Multiplier of 8 seems to work well with Rigidbody Mass of 1.
        movement = transform.TransformDirection(movement);// transform correction A.K.A. "Move the way we are facing"
        
        GetComponentInChildren<Rigidbody>().AddForce(movement * moveSpeed);   // Movement Force

        // captures the movement and rotate according the axis
        if ((Input.GetAxis("Vertical") != 0f || Input.GetAxis("Horizontal") != 0f))
        {
            if (Input.GetAxis("Vertical") >= 0)
                transform.Rotate(new Vector3(0, haxis * rotationSpeed, 0));
            else
                transform.Rotate(new Vector3(0, -haxis * rotationSpeed, 0));
        }

    }
    
    // Dash Coroutine that performs the horizontal dash ability... 
    public IEnumerator Dash(float abilityCoolDown)
    {
        SettingParticlesDashBar();
        movement = new Vector3(0, 0f, 1 * 8);        // Multiplier of 8 seems to work well with Rigidbody Mass of 1.
        movement = transform.TransformDirection(movement);      // transform correction A.K.A. "Move the way we are facing"
        GetComponentInChildren<Rigidbody>().AddForce(movement * dashSpeed); 
        
        yield return new WaitForSeconds(0.2f);
        dashParticle.Stop();

        yield return new WaitForSeconds(abilityCoolDown);
        SetBoolsTrue();
    }
    // Dash Coroutine that performs the jump dash ability...
    public IEnumerator JumpDash(float abilityCoolDown)
    {
        SettingParticlesDashBar();
        playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);

        yield return new WaitForSeconds(0.2f);
        dashParticle.Stop();

        yield return new WaitForSeconds(abilityCoolDown);
        SetBoolsTrue(); 
    }
    // method that initialize the cooldown bar to zero and activate the particle effect...
    private void SettingParticlesDashBar()
    {
        currentDash = 0;//
        dashBar.SetDash(currentDash);//
        dashParticle.Play();//
    }

    // method that sets back to true the booleans in ThirdPersonDash Script...
    private void SetBoolsTrue()
    {
        GetComponent<ThirdPersonDash>().canJump = true;//
        GetComponent<ThirdPersonDash>().canDash = true;//
        currentDash = 3;//
        dashBar.SetDash(currentDash);//
    }

}
