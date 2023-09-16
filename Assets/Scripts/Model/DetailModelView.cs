using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static DetailsConfig;
using System;

public class DetailModelView : MonoBehaviour
{
    public static event Action<int> BuyDetaAction;

    [SerializeField] private TMP_Text nameDetail;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private Image detailImage;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button selectedButton;

    private int price;

    private void Awake()
    {
        buyButton.onClick.AddListener(BuyDetail);
        selectedButton.onClick.AddListener(SelectDetail);
    }

    private void BuyDetail()
    {
        if (GameSaves.currencyIndex >= price)
            BuyDetaAction?.Invoke(price);
    }

    private void SelectDetail()
    {

    }

    public void SetupDetail(Detail detail)
    {
        price = detail.price;
        detailImage.sprite = detail.detailSprite;

        priceText.text = price.ToString() + " $";
    }
}
