using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    #region InspectorFields
    
    #endregion
    
    #region PrivateFields
    
    private Camera mainCamera;
    #endregion
    
    #region UnityMethods
    private void Start()
    {
        mainCamera = Camera.main;
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider != null && hit.transform.GetComponent<HouseController>() != null)
                {
                    var houseId = hit.transform.GetComponent<HouseController>().ArrayIndex;
                    GameController.Instance.ClickOnHouse(houseId);
                }
            }
        }
    }
    #endregion
}
