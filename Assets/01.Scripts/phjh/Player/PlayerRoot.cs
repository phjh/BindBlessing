using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerRoot : MonoBehaviour, Controls.IPlayerMoveActions
{
    [SerializeField] protected PlayerStat stat;

    
    protected Rigidbody _rb;
    protected CharacterController _characterController;
    protected Camera _mainCam;

    protected Controls _controls;

    protected event Action _moveAction;
    protected event Action _attackAction;

    protected Vector2 _mousePos;


    private void Awake()
    {
        _mainCam = Camera.main;
        _rb = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _moveAction?.Invoke();
        }
    }

    public virtual void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
            _attackAction?.Invoke();
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        _mousePos = context.ReadValue<Vector2>();
    }
}
