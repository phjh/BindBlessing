using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemMoveState : EnemyState
{
	public GolemMoveState(EnemyMain enemyMain, EnemyStateMachine stateMachine, string animationBoolName, EnemyStateEnum stateEnum) : base(enemyMain, stateMachine, animationBoolName, stateEnum)
	{
		stateEnum = EnemyStateEnum.Move;
	}

	public override void AnimationFinishTrigger()
	{
		base.AnimationFinishTrigger();
	}

	public override void Enter()
	{
		base.Enter();
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
