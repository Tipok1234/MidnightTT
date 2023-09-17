using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

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
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom("MyRoom", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("Demo");
    }   

    private async void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Demo")
        {
            GameManager.Instance.InstantiateOnlineCar();
            GameScreen.isStopGame = false;
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
