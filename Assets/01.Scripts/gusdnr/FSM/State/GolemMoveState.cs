using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TestTools;

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
		_enemyMain.transform.LookAt(_enemyMain.targetTrm);
		if (_enemyMain.AgentCompo.pathPending)
			return;

		// ������������ �Ÿ��� 0.1f ���ϸ� ������ ������ �����մϴ�.
		if (_enemyMain.AgentCompo.remainingDistance <= 0.1f && !_enemyMain.AgentCompo.pathPending)
		{
			if (!_enemyMain.IsTargetInRange())
				_stateManchine.ChangeState(EnemyStateEnum.Chasing);
			else
			{
				if (_enemyMain.isCompleteCoolDownAttak)
					_stateManchine.ChangeState(EnemyStateEnum.Attack);
				else
					_stateManchine.ChangeState(EnemyStateEnum.Move);
			}
		}
	}

	public override void Exit()
	{
		base.Exit();
	}

	void SetRandomDestination()
	{
		/*float randomAngle = Random.Range(90, 270);
		float random
		// ������ ������ ���� ���� ����
		Vector3 moveDirection = Quaternion.Euler(0f, randomAngle, 0f) * -_enemyMain.transform.forward;

		// ���� ��ġ���� ���� ��ġ�� �̵�
		Vector3 randomPosition = _enemyMain.transform.position + moveDirection * Random.Range(1f, _enemyMain.);

		// NavMesh ���� ��ȿ�� ��ġ�� �̵�
		NavMeshHit hit;
		if (NavMesh.SamplePosition(randomPosition, out hit, moveRange, 1))
		{
			navMeshAgent.SetDestination(hit.position);
		}
*/
		// ���� ������ ������ ��ġ ���� (Y ���� ����)
		Vector3 randomDirection = new Vector3(Random.insideUnitSphere.x, 0f, Random.insideUnitSphere.z) * _enemyMain.RandomRadius; // 10f�� ������ ������
		randomDirection += _enemyMain.transform.position;
		NavMeshHit hit;
		NavMesh.SamplePosition(randomDirection, out hit, 10f, 1);
		Vector3 finalPosition = hit.position;

		_enemyMain.AgentCompo.SetDestination(finalPosition);
	}

}
