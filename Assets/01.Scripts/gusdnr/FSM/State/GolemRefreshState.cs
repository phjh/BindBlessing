using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemRefreshState : EnemyState
{
	public GolemRefreshState(EnemyMain enemyMain, EnemyStateMachine stateMachine, string animationBoolName) : base(enemyMain, stateMachine, animationBoolName)
	{
	}

	public override void AnimationFinishTrigger()
	{
		base.AnimationFinishTrigger();
		_stateManchine.ChangeState(EnemyStateEnum.Idle);
	}

	public override void AnimationPlayingTrigger()
	{
		base.AnimationPlayingTrigger();
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
		_enemyMain.StartCoroutine(_enemyMain.CoolDownAttack());
		base.Exit();
	}
}
