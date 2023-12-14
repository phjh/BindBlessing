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
		_enemyMain.StartCoroutine(_enemyMain.CoolDownAttack());
		_stateManchine.ChangeState(EnemyStateEnum.Idle);

	}

	public override void AnimationPlayingTrigger()
	{
		base.AnimationPlayingTrigger();
		_enemyMain.Attack();
		_enemyMain.AttackShader.SetDefaultColor();
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
