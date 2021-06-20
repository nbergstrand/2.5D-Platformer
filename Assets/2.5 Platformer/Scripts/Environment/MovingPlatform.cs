using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

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
            {
                StartCoroutine(SetTarget(waypoints[1].position));
            }
            else
            {
                StartCoroutine(SetTarget(waypoints[0].position));
            }
                
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Camera.main.gameObject.GetComponent<CinemachineBrain>().enabled = false;
            other.transform.parent = this.gameObject.transform;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Camera.main.gameObject.GetComponent<CinemachineBrain>().enabled = true;
            other.transform.parent = null;
        }
           
    }

    IEnumerator SetTarget(Vector3 position)
    {
        yield return new WaitForSeconds(2f);
        target = position;
    }


}
