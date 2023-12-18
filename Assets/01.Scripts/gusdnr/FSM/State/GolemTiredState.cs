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
	}

	public override void Enter()
	{
		base.Enter();
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
