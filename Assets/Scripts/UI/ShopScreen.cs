using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopScreen : MonoBehaviour
{
    public static event Action<bool> ExitShopScreenAction;

    [SerializeField] private Button exitShopScreenButton;
    [SerializeField] private ScrollViewManager scrollViewManager;
    [SerializeField] private Canvas canvas;
    [SerializeField] private CurrencyView currencyView;

    private void Awake()
    {
        exitShopScreenButton.onClick.AddListener(ExitShopScreen);
    }
    private void Start()
    {
        StartScreen.OpenShopScreenAction += OnOpenShopScreen;
        scrollViewManager.SetupScrollShopDetail();


        currencyView.SetCurrencyText();
    }

    private void OnDestroy()
    {
        StartScreen.OpenShopScreenAction -= OnOpenShopScreen;
    }

    private void OnOpenShopScreen()
    {
        Debug.LogError("Open");
        canvas.enabled = true;
    }

    private void ExitShopScreen()
    {
        ExitShopScreenAction?.Invoke(true);
        canvas.enabled = false;
    }

}
