using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    
    [SerializeField]
    int _points;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.UpdateScore(_points);

            Destroy(gameObject);

            
        }

    }
}
