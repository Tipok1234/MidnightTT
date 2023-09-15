using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    //public static event Action StartGameAction;
    public static event Action OpenShopScreenAction;

    [SerializeField] private Button startGameButton;
    [SerializeField] private Button shopScreenButton;

    private void Awake()
    {
        startGameButton.onClick.AddListener(StartGame);
        shopScreenButton.onClick.AddListener(OpenShopScreen);
    }

    private void Start()
    {
        ShopScreen.ExitShopScreenAction += ActiveScreen;
    }

    private void OnDestroy()
    {
        ShopScreen.ExitShopScreenAction -= ActiveScreen;

    }

    private void StartGame()
    {
        //StartGameAction?.Invoke();
        //SceneManager.LoadScene("Mobile Devices Demo");
        SceneManager.LoadScene("Demo");
    }

    private void OpenShopScreen()
    {
        ActiveScreen(false);
        OpenShopScreenAction?.Invoke();
    }

    private void ActiveScreen(bool active)
    {
        gameObject.SetActive(active);
    }
}
