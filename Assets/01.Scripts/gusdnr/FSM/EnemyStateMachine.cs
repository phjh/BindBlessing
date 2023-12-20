using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.Playables;

public enum EnemyStateEnum
{
	Idle,
	Chasing,
	Turn,
	Attack,
	Move,
	Tired,
	Refresh,
	Die
}

public class EnemyStateMachine
{
    public EnemyState CurrentState { get; private set; }
	public Dictionary<EnemyStateEnum, EnemyState> StateDictionary
		= new Dictionary<EnemyStateEnum, EnemyState>();

	private EnemyMain enemyMain;

	public void Initialize(EnemyStateEnum startState, EnemyMain _enemyMain)
	{
		enemyMain = _enemyMain;
		CurrentState = StateDictionary[startState];
		CurrentState.Enter();
	}


	public void ChangeState(EnemyStateEnum newState)
	{
		CurrentState.Exit();
		CurrentState = StateDictionary[newState];
		CurrentState.Enter();
	}

	public void AddState(EnemyStateEnum state, EnemyState enemyState)
	{
		StateDictionary.Add(state, enemyState);
	}
}
