using System;
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

    bool _canJump;

    [SerializeField]
    private int _score;

    [SerializeField]
    private int _lives;
    
    private float _yVelocity;
       
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
            SceneManager.LoadScene("Level01");
        }


    }
}
