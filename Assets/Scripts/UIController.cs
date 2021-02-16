using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region InspectorFields
    [SerializeField] private UpgradeWindow upgradeWindow;
    [SerializeField] private Text totalMoneyTxt;
    #endregion
    
    #region PrivateFields
    private GameController _gameController;
    #endregion

    #region UnityMethods
    private void Start()
    {
        _gameController = GameController.Instance;
        _gameController.onDataChange += UpdateUi;
        _gameController.onHouseClick += ShowUpgradeWindow;
    }
    #endregion
    
    #region PrivateMethods
    private void UpdateUi()
    {
        totalMoneyTxt.text = $"Total Currency: {_gameController.CurrentMoney}$";
    }
    
    private void ShowUpgradeWindow(int houseId)
    {
        upgradeWindow.Show(houseId, _gameController.Houses[houseId]);
    }
    #endregion
}
