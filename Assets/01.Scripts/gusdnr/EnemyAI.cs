using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class EnemyAI : MonoBehaviour
{
    private Enemy EnemyMain;
    private EnemyAttack enemyAttack;
    private NavMeshAgent agent;

    [Header("Enemy Stat")]
    [SerializeField, Range(1, 100)] private float maxHP;
    [SerializeField, Range(1, 100)] private float speed;
    private float hp;
    [HideInInspector] public float HP => hp;
    [HideInInspector] public bool isAlive = true;

    public Transform target;
    public LayerMask whatIsGround, whatIsPlayer;
    
    public bool isMove;

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float minAttackRange, maxAttackRange;
    public bool playerInDistancRange, playerInAttackRange;

	private void Awake()
	{
		target = GameObject.Find("PlayerObj").transform;
        EnemyMain = GetComponent<Enemy>();
        enemyAttack = GetComponent<EnemyAttack>();
        agent = EnemyMain.AgentCompo;
        hp = maxHP;
        agent.speed = speed;
        isAlive = true;
        isMove = false;
	}

	private void Update()
	{
/*        if(!isAlive)
        {

        }*/
		playerInDistancRange = Physics.CheckSphere(transform.position, maxAttackRange, whatIsPlayer);
		//playerInAttackRange = Physics.CheckSphere(transform.position, minAttackRange + maxAttackRange / 2, whatIsPlayer);
        if(!playerInDistancRange /*&& !playerInAttackRange*/)
        {
            ChasePlayer();
        }
        if(playerInDistancRange /*&& !playerInAttackRange*/)
        {
            Aroundmove();
        }
/*        if(playerInDistancRange && playerInAttackRange)
        {
            AttackPlayer();
        }*/

	}


    private void Aroundmove()
    {
		bool isMoveComplete = false;
		float aroundX = Random.Range(transform.position.x - minAttackRange, transform.position.x + minAttackRange);
		float aroundZ = Random.Range(transform.position.z - minAttackRange, transform.position.z + minAttackRange);
	    Vector3 aroundDir = new Vector3(aroundX, transform.position.y, aroundZ);
        if(!isMoveComplete)
        {
			Debug.Log("Around Moving");
			transform.LookAt(target);
            agent.SetDestination(aroundDir);
		}
		
        if(transform.position == aroundDir )
        {
            isMoveComplete = true;
        }
		isMove = true;

		if (!alreadyAttacked)
		{
		    AttackPlayer();
		}
	}

    private void ChasePlayer()
    {
        Debug.Log("Chasing");
        agent.SetDestination(target.position);
        isMove = true;
    }

    private void AttackPlayer()
    {
        Debug.Log("Attacking");
        agent.SetDestination(transform.position);

        isMove = false;
		alreadyAttacked = true;
        Invoke(nameof(ResetAttack), timeBetweenAttacks);
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
