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
		_enemyMain.isCompleteCoolDownAttak = false;
		_enemyMain.AttackShader.SetDefaultColor();
		_stateManchine.ChangeState(EnemyStateEnum.Tired);

	}

	public override void AnimationPlayingTrigger()
	{
		base.AnimationPlayingTrigger();
		_enemyMain.Attack();
	}

	public override void Enter()
	{
		base.Enter();
		_enemyMain.StopImmediately();
		_enemyMain.AttackShader.SetAttackColor();
	}

	public override void Exit()
	{
		_enemyMain.AgentCompo.ResetPath();
		base.Exit();
	}

	public override void UpdateState()
	{
		base.UpdateState();
		_enemyMain.transform.LookAt(_enemyMain.targetTrm);
	}
}
