using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Vector3 currentEndPoint;
    private Vector3 exitPoint;
    private bool _isGoToExit;
    private Action onComeToHouse;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((currentEndPoint - transform.position).magnitude < 2.5f)
        {
            EndDestination();
        }
    }

    public void SetupHuman(Vector3 housePoint, Vector3 exitPoint, Action endAction)
    {
        onComeToHouse = endAction;
        currentEndPoint = housePoint;
        this.exitPoint = exitPoint;
        _agent.destination = currentEndPoint;
        
    }

    private void EndDestination()
    {
        if (_isGoToExit)
        {
            Destroy(gameObject);
        }
        else
        {
            onComeToHouse?.Invoke();
            _isGoToExit = true;
            currentEndPoint = exitPoint;
            _agent.destination = currentEndPoint;
        }
    }
}
