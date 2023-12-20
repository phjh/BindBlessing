using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "SO/Player/InputReader")]
public class InputReader : ScriptableObject, Controls.IPlayerMoveActions
{
    public event Action _attackAction;

    public Vector2 movedir;
    public Vector2 mousePos;

    public void OnMove(InputAction.CallbackContext context)
    {
        movedir = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
            _attackAction?.Invoke();
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        mousePos = context.ReadValue<Vector2>();
    }
}
