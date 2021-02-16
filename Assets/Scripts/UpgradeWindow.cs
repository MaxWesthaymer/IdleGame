using UnityEngine;
using UnityEngine.UI;

public class UpgradeWindow : MonoBehaviour
{
    #region InspectorFields
    [SerializeField] private GameObject actor;
    [SerializeField] private Button undercoverBtn;
    [SerializeField] private Button upgradeBtn;
    [SerializeField] private Text houseTitle;
    [SerializeField] private Text levelTxt;
    [SerializeField] private Text gettingCurrencyTxx;
    [SerializeField] private Text upgradeCostTxt;
    #endregion
    
    #region PrivateFields
    private GameController _gameController;
    private HouseController _houseController;
    private int _houseId;
    #endregion
    
    #region UnityMethods
    private void Start()
    {
        _gameController = GameController.Instance;
        undercoverBtn.onClick.AddListener(Hide);
        upgradeBtn.onClick.AddListener(UpgradeHouse);
    }
    #endregion

    #region PublicMethods
    public void Show(int houseId, HouseController houseController)
    {
        _houseId = houseId;
        _houseController = houseController;
        FillWindow();
        actor.SetActive(true);
        _gameController.onDataChange += CheckInteractableButton;
    }
    #endregion

    #region PrivateMethods
    private void FillWindow()
    {
        houseTitle.text = $"House {_houseId}";
        levelTxt.text = $"Level: {_houseController.Level}";
        gettingCurrencyTxx.text = $"Getting Currency: {_houseController.GettingCurrency}$";
        upgradeCostTxt.text = $"for {_houseController.UpgradeCost}$";
        CheckInteractableButton();
    }
    
    private void Hide()
    {
        actor.SetActive(false);
        _gameController.onDataChange -= CheckInteractableButton;
    }
    
    private void UpgradeHouse()
    {
        GameController.Instance.UpgradeHouse(_houseId);
        FillWindow();
    }

    private void CheckInteractableButton()
    {
        upgradeBtn.interactable = _gameController.CurrentMoney >= _houseController.UpgradeCost;
    }
    #endregion
}
