using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeGrabber : MonoBehaviour
{
    [SerializeField]
    Vector3 _playerPosition;

    [SerializeField]
    Vector3 _climbUpPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ledge")
        {
            other.GetComponentInParent<Player>().GrabLedge(_playerPosition, _climbUpPosition);
        }
    }
}
