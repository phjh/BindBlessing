using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : PlayerRoot
{
    private Vector2 inputVector;
    
    
    private void OnEnable()
    {
        _moveAction += MovementEvent;
    }

    private void OnDisable()
    {
        _moveAction -= MovementEvent;
    }

    private void MovementEvent()
    {
        Vector3 dir = Quaternion.Euler(0,45,0) *  new Vector3(inputVector.x, 0, inputVector.y).normalized;
        
    }

    public override void OnMove(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
        base.OnMove(context);
    }
}
