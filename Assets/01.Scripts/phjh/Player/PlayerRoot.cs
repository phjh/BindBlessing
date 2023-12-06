using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterController))]
public class PlayerRoot : MonoBehaviour, Controls.IPlayerMoveActions
{
    [SerializeField] protected PlayerStat stat;
    
    protected Rigidbody _rb;
    protected CharacterController _characterController;
    protected Animator _animator;

    protected Controls _controls;
    
    protected Action _moveAction;
    protected Action _attackAction;   
    
    public virtual void OnMove(InputAction.CallbackContext context)
    {
        if(context.performed)
            _moveAction?.Invoke();
    }

    public virtual void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
            _attackAction?.Invoke();
    }
}
