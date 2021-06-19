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

        

        if (distanceToPlayer < 5.5f)
        {
           
            if (Input.GetKeyDown(KeyCode.E))
            {
                _elevator.CallElevator();
                _activationLight.GetComponent<Renderer>().material.color = Color.green;
                _activationLight.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
                _elevatorButton.GetComponent<Renderer>().material.color = Color.green;
                _elevatorButton.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);

            }
        }
    }
    
}
