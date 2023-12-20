using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRoot : MonoBehaviour
{
    public PlayerStat stat;
    
    public InputReader _inputReader;
    
    public Camera _mainCam;
    public Rigidbody _rb;
    public CharacterController _characterController;

    private void Awake()
    {
        _mainCam = Camera.main;
        _rb = GetComponent<Rigidbody>();    
    }
}
