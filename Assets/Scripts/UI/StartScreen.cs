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

    [SerializeField] private Canvas canvas;

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
        canvas.enabled = active;
    }
}
