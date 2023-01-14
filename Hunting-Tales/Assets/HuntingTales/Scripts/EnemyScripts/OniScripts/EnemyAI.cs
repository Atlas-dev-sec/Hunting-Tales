using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5;
    NavMeshAgent navMeshAgent;
    private float distanceToTarget = Mathf.Infinity;
    private bool isProvoked = false;
    private PlayerMovement playerMovementScript;
    [SerializeField] float enemyDamageAttack = 10.0f;
    public HealthBar healthBar;

   
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        // checks every frame the distance between target and enemy
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        // if enemy is provoked calls EngageTarget method
        if (isProvoked)
            EngageTarget();

        // checking is the player is inside the enemy chasing range
        else if (distanceToTarget <= chaseRange)
            isProvoked = true;  
        
    }

    // method that decides between Chase the player or Attack the player...
    private void EngageTarget()
    {
        // if the distance to the player is within the chase range enemry starts persecution...
        if(distanceToTarget <= chaseRange)
           ChaseTarget();
           

        // if the distance to the player is less than the stoppping distance starts attacking the player...
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
            AttackTarget();
        
    }

    // method that positions the enemy with the player position...
    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    // method that attacks the enemy also subtracts player health and update the healthbar value...
    private void AttackTarget()
    {
        playerMovementScript.currentHealth -= enemyDamageAttack;
        healthBar.SetHealth(playerMovementScript.currentHealth);

    }


    // method that is implemented to debug the range of the enemy draw a gismo on screen...
    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);    
    }
}
