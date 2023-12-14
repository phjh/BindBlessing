using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GolemMoveState : EnemyState
{
	public GolemMoveState(EnemyMain enemyMain, EnemyStateMachine stateMachine, string animationBoolName) : base(enemyMain, stateMachine, animationBoolName)
	{
	}

	public override void AnimationFinishTrigger()
	{
		base.AnimationFinishTrigger();
	}

	public override void Enter()
	{
		base.Enter();
		SetRandomDestination();
	}

	public override void UpdateState()
	{
		base.UpdateState();
		if (_enemyMain.AgentCompo.pathPending)
			return;

		// ������������ �Ÿ��� 0.1f ���ϸ� ������ ������ �����մϴ�.
		if (_enemyMain.AgentCompo.remainingDistance <= 0.1f && !_enemyMain.AgentCompo.pathPending)
		{
			_stateManchine.ChangeState(EnemyStateEnum.Idle);
		}
	}

	public override void Exit()
	{
		base.Exit();
	}

	void SetRandomDestination()
	{
		// ���� ������ ������ ��ġ ���� (Y ���� ����)
		Vector3 randomDirection = new Vector3(Random.insideUnitSphere.x, 0f, Random.insideUnitSphere.z) * _enemyMain.RandomRadius; // 10f�� ������ ������
		randomDirection += _enemyMain.transform.position;
		NavMeshHit hit;
		NavMesh.SamplePosition(randomDirection, out hit, 10f, 1);
		Vector3 finalPosition = hit.position;

		_enemyMain.AgentCompo.SetDestination(finalPosition);
	}

}
