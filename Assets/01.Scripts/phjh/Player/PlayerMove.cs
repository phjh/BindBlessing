using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : PlayerRoot
{
    Rigidbody rb;
    public float h, v;
    public Vector3 dir;
    private void Start()
    {
        rb=  GetComponent<Rigidbody>();
    }

    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        dir = Quaternion.Euler(0, 45, 0) * new Vector3(v, 0, -h) * Time.deltaTime * stat.speed.GetStatValue();
        rb.velocity = dir.normalized;
        transform.position += dir;
    }


    /*private Vector2 inputVector;
    
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
        Vector3 dir = Quaternion.Euler(0,45,0) *  new Vector3(inputVector.x, 0,  inputVector.y).normalized * Time.deltaTime * stat.speed.GetStatValue();
        _rb.velocity = dir;
    }*/



}
