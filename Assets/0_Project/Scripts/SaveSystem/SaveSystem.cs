using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    int coins;
    private const string PREF_COIN = "coins";

    void Start()
    {
        coins = PlayerPrefs.GetInt(PREF_COIN, 0);
        if (coins == 0)
            PlayerPrefs.SetInt(PREF_COIN, 0);
    }

    public int GetCoinsOwn() { return coins; }
    public void SetCoins(int coinsTot)
    {
        coins = coinsTot;
        PlayerPrefs.SetInt(PREF_COIN, coins);

    }
}
