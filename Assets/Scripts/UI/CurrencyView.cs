using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private TMP_Text currencyText;

    private void Start()
    {
        DetailModelView.BuyDetaAction += RemoveCurrency;
    }

    private void OnDestroy()
    {
        DetailModelView.BuyDetaAction -= RemoveCurrency;
    }

    public void AddCurency(int currency)
    {
        GameSaves.currencyIndex += currency;
        SetCurrencyText();
    }

    public void RemoveCurrency(int price)
    {
        GameSaves.currencyIndex -= price;
        SetCurrencyText();
    }

    public void SetCurrencyText()
    {
        GameSaves.UpdateCurrency();
        currencyText.text = GameSaves.currencyIndex + " $";
    }
}
