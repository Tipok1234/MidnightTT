using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static DetailsConfig;

public class DetailModelView : MonoBehaviour
{
    [SerializeField] private TMP_Text nameDetail;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private Image detailImage;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button selectedButton;

    //public DetailModelView(Detail detail)
    //{
    //    this.priceText.text = detail.price.ToString();
    //    this.detailImage.sprite = detail.detailSprite;
    //}

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

    public void SetupDetail(Detail detail)
    {
        priceText.text = detail.price.ToString();
        detailImage.sprite = detail.detailSprite;
    }
}
