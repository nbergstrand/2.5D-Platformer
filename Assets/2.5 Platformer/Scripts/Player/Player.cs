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

    [SerializeField]
    private float _pushForce;

    [SerializeField]
    private int _score;

    [SerializeField]
    private int _lives;
           
    Animator _animator;

    private float _yVelocity;
    
    bool _canJump;

    private Vector3 _direction, _velocity;
    
    bool _canWallJump;

    private Vector3 _wallSurfaceNormal;
    
    public static Action<int> OnLivesChange;

    bool _grabbingLedge;
    Vector3 _climbUpPosition;
    
    void Start()
    {
        GameManager.Instance.SetStartPosition(transform.position);
        _animator = GetComponentInChildren<Animator>();

        _controller = GetComponent<CharacterController>();

        if (OnLivesChange != null)
            OnLivesChange(_lives);
    }

    void Update()
    {
        PlayerMovement();
                     
    }

    void PlayerMovement()
    {
        if(_grabbingLedge && Input.GetKeyDown(KeyCode.E))
        {
            _animator.SetTrigger("climbing");
            
        }        


        if (_controller.isGrounded == true)
        {
            
            float horizontalInput = Input.GetAxis("Horizontal");
            _direction = new Vector3(horizontalInput, 0f, 0f);
          
            _velocity = _direction * _speed;

            _animator.SetBool("falling", false);

            if (horizontalInput != 0)
            {
                float rotation = horizontalInput < 0 ? -180f : 0;

                transform.rotation = Quaternion.Euler(0, rotation, 0f);
            }

            _canJump = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _animator.SetTrigger("jump");
                _yVelocity = _jumpHeight;
            }
        }
        else
        {
            
            _animator.SetBool("falling", true);
            if (!_canWallJump && Input.GetKeyDown(KeyCode.Space))
            {
                
                if (_canJump)
                {
                    
                    _yVelocity = _jumpHeight;
                    _canJump = false;
                }

            }

            if (_canWallJump && Input.GetKeyDown(KeyCode.Space))
            {
                _velocity = _wallSurfaceNormal * _speed;
                _yVelocity = _jumpHeight;
            }


            _canWallJump = false;
            _yVelocity -= _gravity * Time.deltaTime;
        }


        _velocity.y = _yVelocity;

        if (_controller.enabled == true)
            _controller.Move(_velocity * Time.deltaTime);

        _animator.SetFloat("speed", Mathf.Abs(_velocity.x * Time.deltaTime));

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

    public void GrabLedge(Vector3 playerPosition, Vector3 climbUpPosition)
    {
        
        _grabbingLedge = true;
        
        _velocity = Vector3.zero;
        _controller.enabled = false;
             
        transform.position = playerPosition;
        _climbUpPosition = climbUpPosition;
        _animator.SetBool("ledgeGrab", true);
    }

    public void SetClimbUpPosition()
    {
        transform.position = _climbUpPosition;
        _velocity = Vector3.zero;
        _animator.SetBool("ledgeGrab", false);
        _grabbingLedge = false;
       _controller.enabled = true;
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
