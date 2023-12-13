using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float HP = 10f;
    public float movementSpeed = 5f;
    public float attackDelay = 0.4f;

	public bool isStartAttack = false;

	public Animator AnimatorCompo;
	public NavMeshAgent AgentCompo;

	public AttackShaderControl AttackShader;

	private EnemyAttack enemyAttack;

	private void Start()
	{
		enemyAttack = GetComponent<EnemyAttack>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			AttackShader.SetAttackColor();
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			AttackShader.SetDefaultColor();
		}
	}

	public void AnimationStartTrigger()
	{
	}

	public void AnimationEndTrigger()
	{
	}

	public void AttackStartTrigger()
	{
		enemyAttack.Attack();
		AttackShader.SetAttackColor();
	}

	public void AttackEndTrigger()
	{
		AnimatorCompo.SetBool("Attack", false);
		isStartAttack = false;
		AttackShader.SetDefaultColor();
	}
}
