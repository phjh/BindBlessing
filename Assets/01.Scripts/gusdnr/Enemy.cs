using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float HP = 10f;
    public float movementSpeed = 5f;
    public float attackDelay = 0.4f;

	public Rigidbody RigidbodyCompo;
	public Animator AnimatorCompo;
	public NavMeshAgent AgentCompo;

	public void AnimationEndTrigger()
	{
	}
}
