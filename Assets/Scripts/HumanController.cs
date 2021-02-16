using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanController : MonoBehaviour
{
    #region InspectorFields
    [SerializeField] private float destinationOffset = 2.5f;
    #endregion
    
    #region PrivateFields
    private NavMeshAgent _agent;
    private Vector3 _currentEndPoint;
    private Vector3 _exitPoint;
    private bool _isGoToExit;
    private Action _onComeToHouse;
    #endregion
    #region UnityMethods
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if ((_currentEndPoint - transform.position).magnitude < destinationOffset)
        {
            EndDestination();
        }
    }
    #endregion

    #region PublicMethods
    public void SetupHuman(Vector3 housePoint, Vector3 exitPoint, Action endAction)
    {
        _onComeToHouse = endAction;
        _currentEndPoint = housePoint;
        _exitPoint = exitPoint;
        _agent.destination = _currentEndPoint;
        
    }
    #endregion
    
    #region PrivateMethods
    private void EndDestination()
    {
        if (_isGoToExit)
        {
            Destroy(gameObject);
        }
        else
        {
            _onComeToHouse?.Invoke();
            _isGoToExit = true;
            _currentEndPoint = _exitPoint;
            _agent.destination = _currentEndPoint;
        }
    }
    #endregion
}
