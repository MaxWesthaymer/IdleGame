using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeWindow : MonoBehaviour
{
    [SerializeField] private GameObject actor;
    [SerializeField] private Button undercoverBtn;
    [SerializeField] private Button upgradeBtn;
    [SerializeField] private Text houseTitle;
    private int _houseId;
    void Start()
    {
        undercoverBtn.onClick.AddListener(Hide);
        upgradeBtn.onClick.AddListener(UpgradeHouse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show(int houseId)
    {
        _houseId = houseId;
        actor.SetActive(true);
        houseTitle.text = $"House {_houseId} level {GameController.Instance.Houses[_houseId].Level}";
    }
    
    public void Hide()
    {
        actor.SetActive(false);
    }
    
    public void UpgradeHouse()
    {
        GameController.Instance.UpgradeHouse(_houseId);
        Show(_houseId);
    }
}
