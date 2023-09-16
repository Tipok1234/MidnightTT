using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class StartScreen : MonoBehaviourPunCallbacks
{
    //public static event Action StartGameAction;
    public static event Action OpenShopScreenAction;

    [SerializeField] private Button startGameButton;
    [SerializeField] private Button shopScreenButton;
    [SerializeField] private Button serverScreenButton;

    [SerializeField] private Canvas canvas;

    [SerializeField] private GameObject serverPanel;

    [Header("Setting Server Room")]
    [SerializeField] private Button createRoom;
    [SerializeField] private Button joinRoom;
    [SerializeField] private Button exitButton;

    [SerializeField] private InputField createField;
    [SerializeField] private InputField joinField;

    private void Awake()
    {
        startGameButton.onClick.AddListener(StartGame);
        shopScreenButton.onClick.AddListener(OpenShopScreen);
        serverScreenButton.onClick.AddListener(ConnectServer);
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


    private void ConnectServer()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.LogError("Load");

        serverPanel.SetActive(true);
    }


    public void CreateRoom()
    {

    }

    public void JoinRoom()
    {

    }
}
