using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField]
    GameObject _activationLight;

    [SerializeField]
    GameObject _elevatorButton;

    [SerializeField]
    int _requiredScore;

    [SerializeField]
    Elevator _elevator;

    Player _player;


    private void Start()
    {
        _player = GameObject.FindObjectOfType<Player>();
    }


    private void Update()
    {
        
        CheckForInput();  
            
    }

    void CheckForInput()
    {
        float distanceToPlayer = Vector3.Distance(_player.transform.position, transform.position);
                       
        if (distanceToPlayer < 2f && GameManager.Instance.CurrentScore >= _requiredScore)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _elevator.CallElevator();
                _activationLight.GetComponent<Renderer>().material.color = Color.green;
                _elevatorButton.GetComponent<Renderer>().material.color = Color.green;

            }
        }
    }


   /* private void OnTriggerStay(Collider other)
    {
        if(other.tag ==  "Player")
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
               
               _activationLight.GetComponent<Renderer>().material.color = Color.green;
               
            }
        }
    }*/
}
