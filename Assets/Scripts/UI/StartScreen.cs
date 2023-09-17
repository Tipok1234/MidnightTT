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
    //public static event Action StartGameAction;
    public static event Action OpenShopScreenAction;
    public static event Action JoinOnlineGame;

    [SerializeField] private Button startGameButton;
    [SerializeField] private Button shopScreenButton;
    [SerializeField] private Button serverScreenButton;

    [SerializeField] private Canvas canvas;

    [SerializeField] private GameObject serverPanel;

    [Header("Setting Server Room")]

    [SerializeField] private Button onlineStart;

    //[SerializeField] private Button createRoom;
    //[SerializeField] private Button joinRoom;
    //[SerializeField] private Button exitButton;

    //[SerializeField] private InputField createField;
    //[SerializeField] private InputField joinField;

    private void Awake()
    {
        GameScreen.isStopGame = true;

        startGameButton.onClick.AddListener(StartGame);
        shopScreenButton.onClick.AddListener(OpenShopScreen);
        //serverScreenButton.onClick.AddListener(ShowRewarded);

        onlineStart.onClick.AddListener(ConnectServer);

        //createRoom.onClick.AddListener(CreateRoom);
        //joinRoom.onClick.AddListener(JoinRoom);
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

    //public override void OnConnectedToMaster()
    //{
    //    Debug.LogError("Load");

    //    //serverPanel.SetActive(true);


    //    RoomOptions roomOptions = new RoomOptions();
    //    roomOptions.MaxPlayers = 2;
    //    PhotonNetwork.CreateRoom(createField.text, roomOptions);
    //}


    //public void CreateRoom()
    //{
    //    RoomOptions roomOptions = new RoomOptions();
    //    roomOptions.MaxPlayers = 2;
    //    PhotonNetwork.CreateRoom(createField.text,roomOptions);
    //}

    //public void JoinRoom()
    //{
    //    PhotonNetwork.JoinRoom(joinField.text);
    //}

    //public override void OnJoinedRoom()
    //{
        
    //    SceneManager.LoadScene("Demo");
    //    Debug.LogError("Joined: " );

    //    GameManager.Instance.InstantiateOnlineCar();
    //}
}
