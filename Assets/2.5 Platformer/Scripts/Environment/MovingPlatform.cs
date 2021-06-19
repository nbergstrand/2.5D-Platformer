using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    

    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float speed;

    Vector3 target;

    

    private void Start()
    {
        target = waypoints[1].position;
    }


    private void FixedUpdate()
    {
        if (transform.position.z != target.z)
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        else
        {
            if(target == waypoints[0].position)
                target = waypoints[1].position;
            else
                target = waypoints[0].position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           
            other.transform.parent = this.gameObject.transform;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
           
    }


}
