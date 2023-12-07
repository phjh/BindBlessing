using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    
    private readonly int attackHash = Animator.StringToHash("Attack");

    [SerializeField]
    private GameObject FireObject;

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
        yield return new WaitForSeconds(0.5f);
        Instantiate(FireObject, transform.position, transform.parent.rotation);
        yield return new WaitForSeconds(0.5f);
        _animator.SetBool(attackHash,false);
    }
}
