using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemTiredState : EnemyState
{
	public GolemTiredState(EnemyMain enemyMain, EnemyStateMachine stateMachine, string animationBoolName) : base(enemyMain, stateMachine, animationBoolName)
	{
	}

	public override void AnimationFinishTrigger()
	{
		base.AnimationFinishTrigger();
		_stateManchine.ChangeState(EnemyStateEnum.Refresh);
	}

	public override void Enter()
	{
		base.Enter();
		_enemyMain.StopImmediately();
	}

	public override void UpdateState()
	{
		base.UpdateState();
	}

	public override void Exit()
	{
		base.Exit();
	}
	
}
