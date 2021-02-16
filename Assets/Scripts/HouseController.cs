using UnityEngine;

public class HouseController : MonoBehaviour
{
    #region Propierties
    public  int ArrayIndex { get; private set; }
    public  int Level { get; private set; }
    public  int GettingCurrency { get; private set; }
    public  int UpgradeCost { get; private set; }
    #endregion
    
    #region PrivateFields
    private int _baseGettingCurrency;
    private int _baseUpgradeCoast;
    #endregion
    

    #region PublicMethods
    public void Initialize(int index, HouseType type)
    {
        ArrayIndex = index;
        Level = 1;
        _baseGettingCurrency = type.BaseGettingCurrency;
        _baseUpgradeCoast = type.BaseUpgradeCoast;
        GettingCurrency = _baseGettingCurrency;
        UpgradeCost = _baseUpgradeCoast;
    }
    public void Upgrade()
    {
        GameController.Instance.SpendMoney(UpgradeCost);
        Level++;
        GettingCurrency += _baseGettingCurrency;
        UpgradeCost = _baseUpgradeCoast * Level;
    }
    #endregion
}
