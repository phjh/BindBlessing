using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationTrigger : MonoBehaviour
{
    private Enemy _enemy;
	private void Awake()
	{
		_enemy = transform.parent.GetComponent<Enemy>();
	}

	private void AnimationEndTrigger()
	{
		_enemy.AnimationEndTrigger();
	}
}
