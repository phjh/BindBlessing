using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Playables;

public enum EnemyNodeEnum
{
    Idle,
    Attack,
    Die,
}

public class EnemyNodeRunner
{
    public EnemyNode CurrentNode { get; private set; }
    public Dictionary<EnemyNodeEnum, EnemyNode> StateDictionary =
        new Dictionary<EnemyNodeEnum, EnemyNode>();

	[Header("Chase Set")]
	public EnemyNode ChaseNode;
	public float sightRange;
	public bool playerInSightRange;

	[Header("Attack Set")]
	public EnemyNode AttackNode;
	public float attackRange;
	public bool playerInAttackRange;

	private Enemy _enemy;

	public void Initialize(EnemyNodeEnum NodeState, Enemy enemy)
	{
		_enemy = enemy;
		CurrentNode = StateDictionary[NodeState];
		CurrentNode.Enter();
	}

	public void ChangeState(EnemyNodeEnum newState)
	{
		CurrentNode.Exit();
		CurrentNode = StateDictionary[newState];
		CurrentNode.Enter();
	}

	public void AddState(EnemyNodeEnum state, EnemyNode EnemyNode)
	{
		StateDictionary.Add(state, EnemyNode);
	}
}
