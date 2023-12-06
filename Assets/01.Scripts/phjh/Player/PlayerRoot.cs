using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum StatType
{
    intelligence,
    mana,
    manaregen,
    criticalChance,
    criticalDamage,
    armor,
    maxHealth,
    speed,
}

[CreateAssetMenu(menuName = "SO/Player/Stat")]
public class PlayerStat : ScriptableObject
{
    [Header("Damage stats")]
    public Stat intelligence;
    public Stat mana;
    public Stat attackSpeed;
    public Stat criticalChance;
    public Stat criticalDamage;
    
    [Header("Living Stats")] 
    public Stat armor;
    public Stat maxHealth;

    [Header("Util Stats")] 
    public Stat speed;
    public Stat manaRegen;
}

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterController))]
public class PlayerRoot : MonoBehaviour, Controls.IPlayerMoveActions
{
    [SerializeField] PlayerStat stat;
    
    public Action _moveAction;
    public Action _attackAction;    
    
    protected Rigidbody _rb;
    protected CharacterController _characterController;
    protected Animator _animator;

    protected Controls _controls;
    
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
