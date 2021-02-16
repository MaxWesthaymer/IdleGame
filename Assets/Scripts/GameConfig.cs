using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Config", menuName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    public HouseType[] HouseTypes;
    public int HumansSpawnRate;

    private void OnValidate()
    {
        foreach (var it in HouseTypes)
        {
            if (it.BaseUpgradeCoast < 0)
                it.BaseUpgradeCoast = 0;
            
            if (it.BaseGettingCurrency < 0)
                it.BaseGettingCurrency = 0;
        }
    }
}

[Serializable]
public class HouseType
{
    public HouseType(int baseUpgradeCoast, int baseGettingCurrency)
    {
        BaseUpgradeCoast = baseUpgradeCoast;
        BaseGettingCurrency = baseGettingCurrency;
    }

    public int BaseUpgradeCoast;
    public int BaseGettingCurrency;
}

