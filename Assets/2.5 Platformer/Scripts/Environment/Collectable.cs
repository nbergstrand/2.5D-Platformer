using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    
    [SerializeField]
    float _bobSpeed = 3.0f;

    [SerializeField]
    float _bobHeight = 0.3f;

    [SerializeField]
    float _rotationSpeed = 80.0f;

    float _startPos;

    [SerializeField]
    int _points;

    void Awake()
    {
        _startPos = transform.localPosition.y;
    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.Rotate(new Vector3(0, _rotationSpeed, 0) * Time.deltaTime, Space.World);
        

        float yLocation = _startPos + (((Mathf.Cos((Time.time) * _bobSpeed) + 1) / 2) * _bobHeight);
        transform.localPosition = new Vector3(transform.localPosition.x, yLocation, transform.localPosition.z);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.UpdateScore(_points);

            Destroy(gameObject);

            
        }

    }
}
