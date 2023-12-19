using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemIdleState : EnemyState
{
	public GolemIdleState(EnemyMain enemyMain, EnemyStateMachine stateMachine, string animationBoolName) : base(enemyMain, stateMachine, animationBoolName)
	{
	}

	public override void Enter()
	{
		base.Enter();
		_enemyMain.StopImmediately(false);
	}

	public override void UpdateState()
	{
		base.UpdateState();
		if (!_enemyMain.IsTargetInRange())
		{
			_stateManchine.ChangeState(EnemyStateEnum.Chasing);
		}
		if (_enemyMain.IsTargetInRange())
		{
			if(_enemyMain.isCompleteCoolDownAttak)
				_stateManchine.ChangeState(EnemyStateEnum.Attack);
		}
	}

	public override void Exit()
	{
		base.Exit();
	}
}
