using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMain : MonoBehaviour
{
	[Header("Enemy Stats")]
	public float HP = 10f;
    public float movementSpeed = 5f;
    public float attackDelay = 3f;
	
	[Header("Enemy Judgment Values")]
	[SerializeField,Range(0,100)] private float minRange;
	[SerializeField,Range(0,100)] private float maxRange;
	[SerializeField] private Transform targetTrm;
	[HideInInspector]public Transform TargetTrm => targetTrm;
	[HideInInspector]public float MinRange => minRange;
	[HideInInspector]public float MaxRange => maxRange;

	[Header("Enemy States")]
	public EnemyState[] EnemyDoingStates;

	public Animator AnimatorCompo {get; private set; }
	public NavMeshAgent AgentCompo { get; private set; }
	public EnemyStateMachine StateMachine { get; private set; }
	public Rigidbody RigidCompo { get; private set; }
	public Collider ColliderCompo { get; private set; }

	public AttackShaderControl AttackShader;

	private EnemyAttack enemyAttack;

	private void Awake()
	{
		Transform visualTrm = transform.Find("Visual");
		AnimatorCompo = visualTrm.GetComponent<Animator>();
		RigidCompo = GetComponent<Rigidbody>();
		ColliderCompo = GetComponent<Collider>();

		StateMachine = new EnemyStateMachine();

		foreach(EnemyState state in EnemyDoingStates)
		{
			string typeName = state._stateEnum.ToString();
			try
			{
				StateMachine.AddState(state._stateEnum, state);
			}
			catch (Exception e)
			{
				Debug.LogError($"{state} State를 받아오지 못했습니다. / 오류: {e.Message}");
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

	public void StopImmediately()
	{
		AgentCompo.isStopped = true;
	}

	public void AnimationEndTrigger()
	{
		StateMachine.CurrentState.AnimationFinishTrigger();
	}
}
