using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : PlayerRoot
{
    Rigidbody rb;
    float h, v;
    Vector3 dir;
    public int nowstate = 0;
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

    private void LateUpdate()
    {
        Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _mainCam.farClipPlane))
        {
            nowstate = 1;
            Vector3 worldPos = hitInfo.point;
            Vector3 ldir = (worldPos - transform.position);
            ldir.y = 0;
            transform.rotation = Quaternion.LookRotation(ldir);
        }
        nowstate = 0;

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
