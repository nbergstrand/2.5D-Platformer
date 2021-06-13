using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float speed;

    [SerializeField]
    GameObject _callButton;

    [SerializeField]
    GameObject _panelLight;

    Vector3 target;
    bool _called;
    Player _player;


    private void Start()
    {
        target = waypoints[1].position;
        _player = GameObject.FindObjectOfType<Player>();
    }

    private void Update()
    {
        CheckForInput();
    }
        
    private void FixedUpdate()
    {

        if(_called)
        {
            if (transform.position != target)
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            else
            {
                if (target == waypoints[0].position)
                {
                    target = waypoints[1].position;
                    _called = false;
                    _callButton.GetComponent<Renderer>().material.color = Color.red;
                    _panelLight.GetComponent<Renderer>().material.color = Color.red;
                }
                else
                {
                    target = waypoints[0].position;
                    _called = false;
                    _callButton.GetComponent<Renderer>().material.color = Color.red;
                    _panelLight.GetComponent<Renderer>().material.color = Color.red;
                }
            }
        }
        
    }

    void CheckForInput()
    {
        float distance = Vector3.Distance(_player.transform.position, _callButton.transform.position);

        if (distance < 2f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CallElevator();
                _callButton.GetComponent<Renderer>().material.color = Color.green;
                _panelLight.GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }

    public void CallElevator()
    {
        _called = true;
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
