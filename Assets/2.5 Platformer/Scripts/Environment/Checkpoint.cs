using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    Vector3 _startPosition;

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player")
        {
            GameManager.Instance.SetStartPosition(_startPosition);
            Destroy(gameObject);
        }
    }
}
