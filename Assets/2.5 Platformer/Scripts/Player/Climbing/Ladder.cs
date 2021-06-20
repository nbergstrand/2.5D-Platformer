using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    
    [SerializeField]
    Vector3 _grabRotation;
    
    [SerializeField]
    Transform _climbUpPosition;

    [SerializeField]
    GameObject _topOfLadderCollider;

    [SerializeField]
    Vector3 _climbUpRotation;

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Ledge")
        {
            _topOfLadderCollider.SetActive(true);
            other.GetComponentInParent<Player>().GrabLadder(_climbUpPosition.position, _grabRotation, _climbUpRotation);
        }
    }
}
