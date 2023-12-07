using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class EnemyAI : MonoBehaviour
{
    [Header("Enemy HP")]
    [SerializeField, Range(1, 100)] private float maxHP;
    private float hp;
    public float HP => hp;
    public bool isAlive = true;

    [SerializeField] private VisualEffect AttackEffect;

    public NavMeshAgent agent;
    public Transform target;
    public LayerMask whatIsGround, whatIsPlayer;
    
    public Vector3 walkPoint;
    bool walkingPointSet;
    public float walkingPointRange;

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

	private void Awake()
	{
		target = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();
        hp = maxHP;
        isAlive = true;
	}

	private void Update()
	{
        if(!isAlive) Destroy(gameObject);
		playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
		playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
            AttackEffect.enabled = false;
        }
        if(playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
            AttackEffect.enabled = false;
        }
        if(playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
            AttackEffect.enabled = true;
        }
	}

	private void Patroling()
    {
        if(!walkingPointSet)
        {
            SearchWalkPoint();
        }

        if(walkingPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 1f)
        {
            walkingPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkingPointRange, walkingPointRange);
        float randomX = Random.Range(-walkingPointRange, walkingPointRange);
    
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        
        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkingPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(target.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(target);

        if (!alreadyAttacked)
        {
            //Attack code
            Debug.Log("Attack");
            AttackEffect.Play();
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    public void TakeDamage(float damage)
    {
        //Damage 받는 애니메이션 재생
        hp -= damage;
        Mathf.Clamp(hp, 0, maxHP);
        if(hp <= 0) isAlive = false;
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
