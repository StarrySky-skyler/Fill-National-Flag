using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    public float inputX { get; set; }
    public float inputY { get; set; }
    
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private bool _isMove;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (inputX != 0 || inputY != 0)
        {
            _isMove = true;
            _animator.SetFloat("inputX", inputX);
            _animator.SetFloat("inputY", inputY);
            _rigidbody2D.velocity = new Vector2(inputX, inputY) * moveSpeed;
        }
        else
        {
            _isMove = false;
            _rigidbody2D.velocity = Vector3.zero;
        }
        
        _animator.SetBool("isMove", _isMove);
    }
    
    /// <summary>
    /// 移动按钮按下
    /// </summary>
    /// <param name="type">1上2下3左4右</param>
    public void BtnMoveDown(int type)
    {
        switch (type)
        {
            case 1:
                inputY = 1;
                break;
            case 2:
                inputY = -1;
                break;
            case 3:
                inputX = -1;
                break;
            case 4:
                inputX = 1;
                break;
        }
    }

    /// <summary>
    /// 移动按钮松开
    /// </summary>
    /// <param name="type">1上2下3左4右</param>
    public void BtnMoveUp(int type)
    {
        switch (type)
        {
            case 1:
                inputY = 0;
                break;
            case 2:
                inputY = 0;
                break;
            case 3:
                inputX = 0;
                break;
            case 4:
                inputX = 0;
                break;
        }
    }
}
