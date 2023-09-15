using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DetailModelView : MonoBehaviour
{
    [SerializeField] private TMP_Text nameDetail;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private Image detailImage;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button selectedButton;

    private void Awake()
    {
        buyButton.onClick.AddListener(BuyDetail);
        selectedButton.onClick.AddListener(SelectDetail);
    }

    private void BuyDetail() 
    {

    }

    private void SelectDetail()
    {

    }

    public void SetupDetail(int price)
    {
        nameDetail.text = price.ToString();
        priceText.text = price.ToString();
        //detailImage.sprite =
    }
}
