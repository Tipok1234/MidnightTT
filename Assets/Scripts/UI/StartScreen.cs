using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class StartScreen : MonoBehaviourPunCallbacks
{
    public static event Action OpenShopScreenAction;
    public static event Action JoinOnlineGame;

    [SerializeField] private Button startGameButton;
    [SerializeField] private Button shopScreenButton;
    [SerializeField] private Button serverScreenButton;

    [SerializeField] private Canvas canvas;

    [SerializeField] private GameObject serverPanel;

    [Header("Setting Server Room")]
    [SerializeField] private Button onlineStart;

    private void Awake()
    {
        GameScreen.isStopGame = true;

        startGameButton.onClick.AddListener(StartGame);
        shopScreenButton.onClick.AddListener(OpenShopScreen);
        onlineStart.onClick.AddListener(ConnectServer);
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
        SceneManager.LoadScene("Demo");

        GameScreen.isStopGame = false;
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


    private void ConnectServer()
    {
        JoinOnlineGame?.Invoke();  
    }

}
