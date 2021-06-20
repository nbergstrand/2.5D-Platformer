using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopOfLadder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponentInChildren<Animator>().SetTrigger("atTop");
            other.GetComponent<CharacterController>().enabled = false;
            gameObject.SetActive(false);
        }
    }
}
