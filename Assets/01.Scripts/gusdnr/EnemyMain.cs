using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyMain : MonoBehaviour
{
	[Header("Enemy Stats")]
	public float HP = 10f;
    public float movementSpeed = 5f;
    public float attackDelay = 3f;
	
	[Header("Enemy Judgment Values")]
	[SerializeField,Range(0,100)] private float minRange;
	[SerializeField,Range(0,100)] private float maxRange;
	[SerializeField] private GameObject AttackEffect;
	public float RandomRadius = 10f;
	public Transform AttackPos;
	[HideInInspector]public bool isCompleteCoolDownAttak;
	[SerializeField] private Transform targetTrm;
	[HideInInspector]public Transform TargetTrm => targetTrm;
	[HideInInspector]public float MinRange => minRange;
	[HideInInspector]public float MaxRange => maxRange;

	[Header("Enemy Name")]
	[SerializeField] private string EnemyName = "Enemy";

	public Animator AnimatorCompo {get; private set; }
	public NavMeshAgent AgentCompo { get; private set; }
	public EnemyStateMachine StateMachine { get; private set; }
	public Rigidbody RigidCompo { get; private set; }
	public Collider ColliderCompo { get; private set; }

	public AttackShaderControl AttackShader;

	private void Awake()
	{
		Transform visualTrm = transform.Find("Visual");
		AnimatorCompo = visualTrm.GetComponent<Animator>();
		RigidCompo = GetComponent<Rigidbody>();
		ColliderCompo = GetComponent<Collider>();

		isCompleteCoolDownAttak = true;

		StateMachine = new EnemyStateMachine();

		foreach(EnemyStateEnum stateEnum in Enum.GetValues(typeof(EnemyStateEnum)))
		{
			string typeName = stateEnum.ToString();
			try
			{
				Type type = Type.GetType($"{EnemyName}{typeName}State");
				EnemyState stateInstance = Activator.CreateInstance(type, this, StateMachine, typeName) as EnemyState;

				StateMachine.AddState(stateEnum, stateInstance);
			}
			catch (Exception e)
			{
				Debug.LogError($"{stateEnum} State를 받아오지 못했습니다. / 오류: {e.Message}");
			}
		}
	}

	private void Start()
	{
		StateMachine.Initialize(EnemyStateEnum.Idle, this);
	}

	protected virtual void Update()
	{
		StateMachine.CurrentState.UpdateState();
	}

	public void CoolDownAttack()
	{
		isCompleteCoolDownAttak = true;
	}

	public void StartImmediately()
	{
		AgentCompo.isStopped = false;
	}

	public void StopImmediately()
	{
		AgentCompo.isStopped = true;
	}

	public void Attack()
	{
		Instantiate(AttackEffect, AttackPos.position, transform.rotation);
	}

	public void AnimationEndTrigger()
	{
		StateMachine.CurrentState.AnimationFinishTrigger();
	}

	public void AnimationPlayingTrigger()
	{
		StateMachine.CurrentState.AnimationPlayingTrigger();
	}

	public void OnDie()
	{
		Destroy(gameObject);
	} 

	public bool IsTargetInRange()
	{
		float distanceToTarget = Vector3.Distance(transform.position, TargetTrm.position);
		return distanceToTarget >= MinRange && distanceToTarget <= MaxRange;
	}

}
