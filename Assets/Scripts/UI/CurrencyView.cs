using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private TMP_Text currencyText;

    private int currentCurrency = 100;

    public void AddCurency(int currency)
    {
        currentCurrency += currency;
    }

    public void RemoveCurrency(int price)
    {
        currentCurrency -= price;
    }

    public void SetCurrencyText()
    {
        currencyText.text = currentCurrency.ToString() + " $";
    }
}
