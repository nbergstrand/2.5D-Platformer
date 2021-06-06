using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private int _score;

    [SerializeField]
    private int _lives;

    [SerializeField]
    Vector3 _startPos;

    private float _yVelocity;

    bool _canJump;
    bool _isAlive;

    public static Action<int> OnLivesChange;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();

        if (OnLivesChange != null)
            OnLivesChange(_lives);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0f, 0f);
        Vector3 velocity = direction * _speed;

        if (_controller.isGrounded == true)
        {

            _canJump = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
            }
        }
        else
        {
            if (_canJump && Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canJump = false;
            }

            _yVelocity -= _gravity * Time.deltaTime;
        }


        velocity.y = _yVelocity;

        _controller.Move(velocity * Time.deltaTime);

        if(transform.position.y < -10.0)
        {
            _lives--;
            transform.position = _startPos;

            if (OnLivesChange != null)
                OnLivesChange(_lives);

        }


    }
}
