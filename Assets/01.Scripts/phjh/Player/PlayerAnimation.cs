using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    Quaternion rot;
    
    private readonly int attackHash = Animator.StringToHash("Attack");

    [SerializeField]
    private GameObject FireObject;
    [SerializeField]
    private GameObject targetObject;

    public bool isAttacking = false;

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
        Transform trm = GetComponentInChildren<Transform>();
        rot = trm.rotation;
        _animator.SetBool(attackHash,true);
        isAttacking = true;
        yield return new WaitForSeconds(0.5f);
        Destroy(Instantiate(FireObject, targetObject.transform.position, transform.rotation),4);
        yield return new WaitForSeconds(0.3f);
        isAttacking = false;
        _animator.SetBool(attackHash,false);
        trm.rotation = rot;
    }
}
