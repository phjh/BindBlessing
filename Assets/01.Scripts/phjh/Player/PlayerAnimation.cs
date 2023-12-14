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
        _animator = GetComponentInChildren<Animator>();
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
        Quaternion rot = transform.GetChild(0).transform.rotation;
        _animator.SetBool(attackHash,true);
        yield return new WaitForSeconds(0.6f);
        Destroy(Instantiate(FireObject, FirePosition.position, transform.rotation), 4);
        yield return new WaitForSeconds(0.65f);
        _animator.SetBool(attackHash,false);
        transform.GetChild(0).transform.rotation = Quaternion.Euler(rot.x, rot.y + 180, rot.z);
    }
}
