using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject AttackEffect;
    private Enemy EnemyMain;

    public Transform AttackPos;

	private void Awake()
	{
		EnemyMain = GetComponent<Enemy>();
	}

	public void Attack()
    {
		Instantiate(AttackEffect, AttackPos.position, transform.rotation);
    }
}
