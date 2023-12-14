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

		// 목적지까지의 거리가 0.1f 이하면 도착한 것으로 간주합니다.
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
		// 구역 내에서 무작위 위치 설정 (Y 값을 제외)
		Vector3 randomDirection = new Vector3(Random.insideUnitSphere.x, 0f, Random.insideUnitSphere.z) * _enemyMain.RandomRadius; // 10f는 구역의 반지름
		randomDirection += _enemyMain.transform.position;
		NavMeshHit hit;
		NavMesh.SamplePosition(randomDirection, out hit, 10f, 1);
		Vector3 finalPosition = hit.position;

		_enemyMain.AgentCompo.SetDestination(finalPosition);
	}

}
