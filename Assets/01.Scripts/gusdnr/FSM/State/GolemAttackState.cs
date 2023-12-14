using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAttackState : EnemyState
{
	public GolemAttackState(EnemyMain enemyMain, EnemyStateMachine stateMachine, string animationBoolName) : base(enemyMain, stateMachine, animationBoolName)
	{
	}

	public override void AnimationFinishTrigger()
	{
		base.AnimationFinishTrigger();
	}

	public override void AnimationPlayingTrigger()
	{
		base.AnimationPlayingTrigger();
		
	}

	public override void Enter()
	{
		base.Enter();
		_enemyMain.AttackShader.SetAttackColor();
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
