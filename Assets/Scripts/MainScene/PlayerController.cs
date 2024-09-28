using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    
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
        var inputX = Input.GetAxisRaw("Horizontal");
        var inputY = Input.GetAxisRaw("Vertical");
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
}
