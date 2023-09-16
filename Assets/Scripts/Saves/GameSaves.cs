using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaves : MonoBehaviour
{
    public static string levelKey = "levelKey";
    public static string detailKey = "DetailKey";
    public static string currencyKey = "CurrencyKey";

    public static int levelIndex;
    public static int detailIndex;
    public static int currencyIndex;


    private void Awake()
    {
        levelIndex = PlayerPrefs.GetInt(levelKey);
        detailIndex = PlayerPrefs.GetInt(detailKey);
        currencyIndex = PlayerPrefs.GetInt(currencyKey);


        Debug.LogError("CurrencyIndex: " + currencyIndex);
    }

    public static void UpdateCurrency()
    {
        PlayerPrefs.SetInt(currencyKey, currencyIndex);
    }

}
