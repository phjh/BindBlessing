using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : Controls.IPlayerMoveActions
{
    public Vector2 inputVector;
    
    public Action moveAction;
    public Action attackAction;   
    
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            inputVector = context.ReadValue<Vector2>();
            moveAction?.Invoke();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
            attackAction?.Invoke();
    }
}
