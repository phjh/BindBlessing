using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject AttackEffect;
    
    public Transform AttackPos;

    public void Attack()
    {
        Instantiate(AttackEffect, AttackPos.position, transform.rotation);
    }
}
