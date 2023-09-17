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

    private Detail detail;

    public static string lastDetailBuyKey = "LastBuyDetail";
    public static string lastCarBuyKey = "LastCarBuy";
    
    private void Awake()
    {
        buyButton.onClick.AddListener(BuyDetail);
        selectedButton.onClick.AddListener(SelectDetail);
    }

    private void Start()
    {
        var newKey = PlayerPrefs.GetString(detail.key);

        if (!string.IsNullOrEmpty(newKey))
        {
            RefreshButton();
        }

        if (detail.price == 0)
            RefreshButton();

        SetLastDetail();
    }


    public void SetLastDetail()
    {
        var lastKey = PlayerPrefs.GetString(lastDetailBuyKey);
        var lastDetail = GameManager.Instance.Config.GetDetail(lastKey);

        if (lastDetail != null)
            GameManager.Instance.Car.ModelView.SetColor(lastDetail.material);
    }

    private void BuyDetail()
    {
        if (GameSaves.currencyIndex >= detail.price)
        {
            if (detail.material != null)
            {
                GameManager.Instance.Car.ModelView.SetColor(detail.material);
                PlayerPrefs.SetString(detail.key, detail.key);
                PlayerPrefs.SetString(lastDetailBuyKey, detail.key);
            }

            if(detail.car != null)
            {
                PlayerPrefs.SetString(detail.key, detail.key);
                PlayerPrefs.SetString(lastCarBuyKey, detail.key);
                GameManager.Instance.Car.ModelView.SetColor(detail.material);
                GameManager.Instance.ChangeCar();
            }

            BuyDetaAction?.Invoke(detail.price);
        }

        RefreshButton();
    }

    private void SelectDetail()
    {
        if (detail.material != null)
        {
            GameManager.Instance.Car.ModelView.SetColor(detail.material);
            PlayerPrefs.SetString(lastDetailBuyKey, detail.key);
        }

        if (detail.car != null)
        {
            PlayerPrefs.SetString(lastCarBuyKey, detail.key);
            GameManager.Instance.ChangeCar();
        }
    }

    private void RefreshButton()
    {
        buyButton.gameObject.SetActive(false);
        selectedButton.gameObject.SetActive(true);
    }

    public void SetupDetail(Detail detail)
    {
        this.detail = detail;
        detailImage.sprite = detail.detailSprite;
        priceText.text = detail.price.ToString() + " $";
        nameDetail.text = detail.key;
    }
}
