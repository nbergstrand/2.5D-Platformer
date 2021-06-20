using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeGrabber : MonoBehaviour
{
    
    [SerializeField]
    Transform _playerPosition;
    
    [SerializeField]
    Transform _climbUpPosition;

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Ledge")
        {
            other.GetComponentInParent<Player>().GrabLedge(_playerPosition.position, _climbUpPosition.position);
        }
    }
}
