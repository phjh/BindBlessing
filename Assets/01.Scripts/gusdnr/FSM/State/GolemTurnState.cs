using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemTurnState : EnemyState
{
	private Transform targetTrm;

	public GolemTurnState(EnemyMain enemyMain, EnemyStateMachine stateMachine, string animationBoolName) : base(enemyMain, stateMachine, animationBoolName)
	{
	}

	public override void AnimationFinishTrigger()
	{
		base.AnimationFinishTrigger();
		_stateManchine.ChangeState(EnemyStateEnum.Idle);
	}

	public override void Enter()
	{
		base.Enter();
		targetTrm = _enemyMain.targetTrm;
	}

	public override void UpdateState()
	{
		base.UpdateState();
		Vector3 direction = targetTrm.position - _enemyMain.transform.position;
		Quaternion rotationAngle = Quaternion.Slerp(_enemyMain.transform.rotation, Quaternion.LookRotation(direction), _enemyMain.rotSpeed * Time.deltaTime);
		rotationAngle.x = rotationAngle.z = 0;
		_enemyMain.transform.rotation = rotationAngle;
	}

	public override void Exit()
	{
		base.Exit();
	}
}
