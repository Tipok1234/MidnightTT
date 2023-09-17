using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class NetworkManager : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        StartScreen.JoinOnlineGame += OnlineGame;
    }

    private void OnDestroy()
    {
        StartScreen.JoinOnlineGame -= OnlineGame;
    }

    public void OnlineGame()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.LogError("Load");

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom("MyRoom", roomOptions);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {

    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
       
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom("MyRoom");
    }

    public override void OnJoinedRoom()
    {

        SceneManager.sceneLoaded += OnSceneLoaded;

        SceneManager.LoadScene("Demo");
        Debug.LogError("Joined: ");

        //GameManager.Instance.InstantiateOnlineCar();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Demo")
        {
            GameManager.Instance.InstantiateOnlineCar();

            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
