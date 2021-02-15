using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    
    #region InspectorFields
    [SerializeField] private GameConfig gameConfig;
    [SerializeField] private float offsetBetweenImages;
    [SerializeField] private float timeToNextLevel;
    [SerializeField] private HouseController[] houses;
    #endregion
    
    #region Events
    public event Action onDataChange;
    public event Action<int> onHouseClick;
    #endregion
    
    #region Propierties
    public int DoneScore { get; private set; }
    public int WrongScore { get; private set; }
    public int CurrentLevel { get; private set; }
    public int CurrentMoney { get; private set; }

    public HouseController[] Houses => houses;
    #endregion
    
    #region PrivateFields

    #endregion

    #region UnityMethods
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        for (var i = 0; i < houses.Length; i++)
        {
            var house = houses[i];
            house.SetIndex(i);
        }

        CurrentMoney = 0;
        onDataChange?.Invoke();
    }
    #endregion
    

    #region PublicMethods

    
    public void HumanPaid(int houseId)
    {
        CurrentMoney += houses[houseId].MoneyGet;
        onDataChange?.Invoke();
    }

    public int GetRandomHouseId()
    {
        return Random.Range(0, houses.Length);
    }
    public Vector3 GetHousePosition(int houseId)
    {
        return houses[houseId].transform.position;
    }
    
    public void ClickOnHouse(int houseId)
    {
        onHouseClick?.Invoke(houseId);
    }
    
    public void UpgradeHouse(int houseId)
    {
        houses[houseId].Upgrade();
    }
    #endregion

    #region PrivateMethods
 
    #endregion
}
