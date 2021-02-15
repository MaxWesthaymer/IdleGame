using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
   
    #region Propierties
    public  int ArrayIndex { get; private set; }
    public  int Level { get; private set; }
    public  int MoneyGet { get; private set; }
    #endregion
    
    #region PrivateFields
    private Animator _animator;
    #endregion
    
    #region UnityMethods
    private void Start()
    {
        
    }
    #endregion

    #region PublicMethods
    public void SetIndex(int index)
    {
        ArrayIndex = index;
        Level = 0;
        MoneyGet = 10;
    }
    
    public void Upgrade()
    {
        Level++;
        MoneyGet += 20;
    }
    
    
    #endregion
}
