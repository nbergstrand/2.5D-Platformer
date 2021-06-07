﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private float _speed = 10;

    [SerializeField]
    private float _gravity = 5;

    [SerializeField]
    private float _jumpHeight = 10f;

    [SerializeField]
    private float _pushForce;

    private float _yVelocity;
    
    bool _canJump;
    bool _canWallJump;
    private Vector3 _direction, _velocity;
    private Vector3 _wallSurfaceNormal;


    [SerializeField]
    private int _score;

    [SerializeField]
    private int _lives;
          
    public static Action<int> OnLivesChange;
    
    void Start()
    {
        GameManager.Instance.SetStartPosition(transform.position);

        _controller = GetComponent<CharacterController>();

        if (OnLivesChange != null)
            OnLivesChange(_lives);
    }

    void Update()
    {
        

        if (_controller.isGrounded == true)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            _direction = new Vector3(horizontalInput, 0f, 0f);
            _velocity = _direction * _speed;

            _canJump = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                 _yVelocity = _jumpHeight;
            }
        }
        else
        {            

            if (!_canWallJump && Input.GetKeyDown(KeyCode.Space))
            {
                if(_canJump)
                {
                    _yVelocity = _jumpHeight;
                    _canJump = false;
                }
                                
            }

            if(_canWallJump && Input.GetKeyDown(KeyCode.Space))
            {
                _velocity = _wallSurfaceNormal * _speed;
                _yVelocity = _jumpHeight;
            }


            _canWallJump = false;
            _yVelocity -= _gravity * Time.deltaTime;
        }


        _velocity.y = _yVelocity;

        _controller.Move(_velocity * Time.deltaTime);



    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
       
        if(!_controller.isGrounded && hit.transform.tag == "Wall")
        {
            _canWallJump = true;
            _wallSurfaceNormal = hit.normal;
                       
        }

        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb != null && !rb.isKinematic)
        {
            rb.velocity = hit.moveDirection * _pushForce;
        }


    }

    public void KillPlayer()
    {
        _lives--;
        transform.position = GameManager.Instance.StartPosition;

        if (OnLivesChange != null)
            OnLivesChange(_lives);

        if(_lives <= 0)
        {
            GameManager.Instance.ResetScore();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


    }
}
