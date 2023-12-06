using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerRoot : MonoBehaviour
{
    [SerializeField] protected PlayerStat stat;
    
    protected Rigidbody _rb;
    protected CharacterController _characterController;

    /*protected Controls _controls;
    
    protected Action _moveAction;
    protected Action _attackAction;*/
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();
    }

    /*public void OnMove(InputAction.CallbackContext context)
    {
        InputValue = context.ReadValue<Vector2>();
        if (context.performed)
        {
            _moveAction?.Invoke();
        }
    }

    public virtual void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
            _attackAction?.Invoke();
    }*/
}
