using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemChasingState : EnemyState
{
	public GolemChasingState(EnemyMain enemyMain, EnemyStateMachine stateMachine, string animationBoolName) : base(enemyMain, stateMachine, animationBoolName)
	{
	}

	public override void Enter()
	{
		base.Enter();
		_enemyMain.AgentCompo.SetDestination(_enemyMain.targetTrm.position);
	}

	public override void UpdateState()
	{
		base.UpdateState();
		if(_enemyMain.IsTargetInRange())
			_stateManchine.ChangeState(EnemyStateEnum.Idle);
	}

	public override void Exit()
	{
		base.Exit();
	}

	
}
