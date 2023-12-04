using UnityEngine;
using UnityEngine.AI;

public class EnemyNode
{
	protected Enemy _enemy;
	protected Rigidbody _rigidbody;
	protected EnemyNodeRunner _nodeRunner;
	protected bool _triggerCalled;
	protected NavMeshAgent _agent;
	protected int _animBoolHash;

	public EnemyNode(Enemy enemy, EnemyNodeRunner nodeRunner, string animationBoolName)
	{
		_enemy = enemy;
		_nodeRunner = nodeRunner;
		_animBoolHash = Animator.StringToHash(animationBoolName);
		_agent = enemy.AgentCompo;
		_rigidbody = enemy.RigidbodyCompo;
	}

	public virtual void Enter()
	{
		_enemy.AnimatorCompo.SetBool(_animBoolHash, true);
		_triggerCalled = false;
	}

	public virtual void UpdateState()
	{
		
	}

	public virtual void Exit()
	{
		_enemy.AnimatorCompo.SetBool(_animBoolHash, false);
	}

	public virtual void AnimatorFinishTrigger()
	{
		_triggerCalled = true;
	}
}
