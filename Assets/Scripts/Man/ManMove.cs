 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ManMove : MonoBehaviour
{
    private Camera _cameraMain;
    private NavMeshAgent _agent;
    void Start()
    {
        _cameraMain = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit _hit;
            if (Physics.Raycast(_cameraMain.ScreenPointToRay(Input.mousePosition), out _hit)) 
            {
                _agent.SetDestination(_hit.point);
            }
        }
    }
}
