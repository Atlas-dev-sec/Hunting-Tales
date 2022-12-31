using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
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
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
            EngageTarget();

         // checking is the player is inside the enemy chasing range
        else if (distanceToTarget <= chaseRange)
            isProvoked = true;       
    }

    private void EngageTarget()
    {
        if(distanceToTarget <= chaseRange)
           ChaseTarget(); 

        if (distanceToTarget <= navMeshAgent.stoppingDistance )
            AttackTarget();
        
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        //Debug.Log(name + "Has seeked and attacking" + target.name);
        //playerMovementScript.currentHealth -= enemyDamageAttack * Time.deltaTime;
        playerMovementScript.currentHealth -= enemyDamageAttack;
        healthBar.SetHealth(playerMovementScript.currentHealth);

    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);    
    }
}
