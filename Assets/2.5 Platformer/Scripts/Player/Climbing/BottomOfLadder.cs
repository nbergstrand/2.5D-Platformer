using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomOfLadder : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && Input.GetKey(KeyCode.DownArrow))
        {
            other.GetComponent<Player>().ClimbDownLadder();
        }
    }
}
