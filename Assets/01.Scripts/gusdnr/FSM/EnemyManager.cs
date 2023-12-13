using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private enum State
    {
        Idle,
        Chasing,
        Move,
        Attack,
		Die
    }

	[Header("Enemy Stats")]
	public float minRange;
	public float maxRange;

    private State currentState;

	private void Awake()
	{
		currentState = State.Idle;
	}

	private void Update()
	{
		
	}
}
