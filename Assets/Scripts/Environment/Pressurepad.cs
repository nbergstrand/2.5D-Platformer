using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressurepad : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Box")
        {
            Transform box = other.GetComponent<Transform>();
            float distance = Vector3.Distance(box.position, transform.position);

            if (distance < 0.05f)
            {
               box.GetComponent<Rigidbody>().isKinematic = true;
               box.GetComponent<Renderer>().material.color = Color.green;
               Destroy(box.gameObject, 0.5f); 
                               
            }

        }
    }
}
