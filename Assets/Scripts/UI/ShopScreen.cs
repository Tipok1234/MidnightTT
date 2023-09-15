using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScreen : MonoBehaviour
{
    public static event Action<bool> ExitShopScreenAction;

    [SerializeField] private Button exitShopScreenButton;
    [SerializeField] private ScrollViewManager scrollViewManager;

    private void Awake()
    {
        exitShopScreenButton.onClick.AddListener(ExitShopScreen);
    }
    private void Start()
    {
        StartScreen.OpenShopScreenAction += OnOpenShopScreen;
        scrollViewManager.SetupScrollShopDetail();
    }
    private void OnDestroy()
    {
        StartScreen.OpenShopScreenAction -= OnOpenShopScreen;
    }

    private void OnOpenShopScreen()
    {
        Debug.LogError("Open");
        gameObject.SetActive(true);
    }

    private void ExitShopScreen()
    {
        ExitShopScreenAction?.Invoke(true);
        gameObject.SetActive(false);
    }

}
