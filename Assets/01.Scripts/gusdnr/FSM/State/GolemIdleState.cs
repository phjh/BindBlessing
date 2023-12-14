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
			else if (_enemyMain.isCompleteCoolDownAttak)
				_stateManchine.ChangeState(EnemyStateEnum.Move);
		}
	}

	public override void Exit()
	{
		base.Exit();
	}
}
