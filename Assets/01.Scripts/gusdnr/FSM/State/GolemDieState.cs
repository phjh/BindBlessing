using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemDieState : EnemyState
{
	public GolemDieState(EnemyMain enemyMain, EnemyStateMachine stateMachine, string animationBoolName, EnemyStateEnum stateEnum) : base(enemyMain, stateMachine, animationBoolName, stateEnum)
	{
		stateEnum = EnemyStateEnum.Die;
	}

	public override void AnimationFinishTrigger()
	{
		base.AnimationFinishTrigger();
		_enemyMain.OnDie();
	}

	public override void Enter()
	{
		base.Enter();
		_enemyMain.StopImmediately();
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void UpdateState()
	{
		base.UpdateState();
	}

}
