using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationTrigger : MonoBehaviour
{
	private EnemyMain _enemy;
	private void Awake()
	{
		_enemy = transform.parent.GetComponent<EnemyMain>();
	}

	/*public void AnimationStartTrigger()
	{
		_enemy.AnimationStartTrigger();
	}

	public void AnimationEndTrigger()
	{
		_enemy.AnimationEndTrigger();
	}

	public void AttackStartTrigger()
	{
		_enemy.AttackStartTrigger();
	}

	public void AttackEndTrigger()
	{
		_enemy.AttackEndTrigger();
	}*/
}
