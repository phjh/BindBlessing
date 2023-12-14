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

	public void AnimationEndTrigger()
	{
		_enemy.AnimationEndTrigger();
	}

	public void AnimationPlayingTrigger()
	{
		_enemy.AnimationPlayingTrigger();
	}

}
