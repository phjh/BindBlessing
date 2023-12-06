using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    
    private readonly int attackHash = Animator.StringToHash("Attack");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(attack());
        }
    }

    IEnumerator attack()
    {
        _animator.SetBool(attackHash,true);
        yield return new WaitForSeconds(1f);
        _animator.SetBool(attackHash,false);
    }
}
