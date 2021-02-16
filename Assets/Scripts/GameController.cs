using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    
    #region InspectorFields
    [SerializeField] private GameConfig gameConfig;
    [SerializeField] private HouseController[] houses;
    #endregion
    
    #region Events
    public event Action onDataChange;
    public event Action<int> onHouseClick;
    #endregion
    
    #region Propierties
    public int CurrentMoney { get; private set; }
    public HouseController[] Houses => houses;
    public int HumansSpawnRate => gameConfig.HumansSpawnRate;
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
        InitializeHouses();
        CurrentMoney = 0;
        onDataChange?.Invoke();
    }
    #endregion
    

    #region PublicMethods
    public void HumanPaid(int houseId)
    {
        CurrentMoney += houses[houseId].GettingCurrency;
        onDataChange?.Invoke();
    }
    
    public void SpendMoney(int value)
    {
        CurrentMoney -= value;
        if (CurrentMoney < 0)
            CurrentMoney = 0;
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
    private void InitializeHouses()
    {
        if (gameConfig.HouseTypes.Length >= houses.Length)
        {
            for (var i = 0; i < houses.Length; i++)
            {
                var house = houses[i];
                house.Initialize(i, gameConfig.HouseTypes[i]);
            }
        }
        else
        {
            Debug.LogError("HouseTypes in GameConfig less then houses count");
        }
    }
    #endregion
}
