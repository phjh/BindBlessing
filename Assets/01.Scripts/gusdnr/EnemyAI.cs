using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class EnemyAI : MonoBehaviour
{
    private Enemy EnemyMain;

    [Header("Enemy Stat")]
    [SerializeField, Range(1, 100)] private float maxHP;
    [SerializeField, Range(1, 100)] private float speed;
    private float hp;
    [HideInInspector] public float HP => hp;
    [HideInInspector] public bool isAlive = true;

    public NavMeshAgent agent;
    public Transform target;
    public EnemyAttack enemyAttack;
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
        EnemyMain = GetComponent<Enemy>();
        agent = GetComponent<NavMeshAgent>();
        enemyAttack = GetComponent<EnemyAttack>();
        hp = maxHP;
        agent.speed = speed;
        isAlive = true;
	}

	private void Update()
	{
        if(!isAlive)
        {

        }
		playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
		playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        if(playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
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

    private void Aroundmove()
    {

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
            EnemyMain.AnimatorCompo.SetBool("Attack", true);
            if(EnemyMain.isStartAttack) enemyAttack.Attack();
            enemyAttack.Attack();
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
