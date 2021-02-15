using System.Collections;
using System.Collections.Generic;
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
//        doneScoreTxt.text = $"{_gameController.DoneScore}";
       //wrongScoreTxt.text = $"{_gameController.WrongScore}";
       //levelTxt.text = $"Уровень {_gameController.CurrentLevel + 1}";
       totalMoneyTxt.text = $"Денег всего {_gameController.CurrentMoney}";
    }
    
    private void ShowUpgradeWindow(int houseId)
    {
        upgradeWindow.Show(houseId);
    }
    #endregion
}
