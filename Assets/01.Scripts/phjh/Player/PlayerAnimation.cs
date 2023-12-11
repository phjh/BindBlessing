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
    [SerializeField]
    private Transform FirePosition;

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
        Destroy(Instantiate(FireObject, FirePosition.position, transform.parent.rotation), 5);
        //yield return new WaitForSeconds(0.8f);
        _animator.SetBool(attackHash,false);
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
