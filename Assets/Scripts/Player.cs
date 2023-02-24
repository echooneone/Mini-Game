using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _speed;
    public float walkSpeed;
    public float runSpeed;
    private Animator _animator;
    public Vector3 playerInput;
    //攻击间隔计时器
    private float _timer;
    public bool isAtk = false;
    public float atkTime; //一次攻击的时间

    private void Start()
    {
        _speed = walkSpeed;
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        //攻击时间结束
        if (Time.time > _timer + atkTime)
        {
            isAtk = false;
        }
        
        if (!isAtk && Input.GetKeyDown(KeyCode.J))
        {
            _animator.SetTrigger("Atk");
            isAtk = true;
            _timer = Time.time;
        }
        

        //正在攻击则停止移动输入
        playerInput = (!isAtk ? new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) : Vector3.zero).normalized;

        //上下左右行走奔跑动画
        _animator.SetFloat("X", playerInput.x);
        _animator.SetFloat("Y", playerInput.y);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _speed = runSpeed;
            _animator.SetBool("isRun", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed = walkSpeed;
            _animator.SetBool("isRun", false);
        }

        transform.position += playerInput * _speed * Time.deltaTime;
    }
}