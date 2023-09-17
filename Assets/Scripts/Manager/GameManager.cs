using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private DetailsConfig config;
    [SerializeField] private AdsManager adsManager;
    public PlayerController Car { get; private set; }
    public DetailsConfig Config => config;

    public AdsManager AdsManager => adsManager;

    private int posX = -6;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if (!PhotonNetwork.IsConnected)
            StartGame();
    }

    public void StartGame()
    {
        var lastCarKey = PlayerPrefs.GetString(DetailModelView.lastCarBuyKey);

        if (string.IsNullOrEmpty(lastCarKey))
        {
            Car = Instantiate(Config.details[0].car, gameObject.transform);
        }
        else
        {
            var lastCar = Config.GetDetail(lastCarKey);
            Car = Instantiate(lastCar.car, gameObject.transform);
        }

        SetStartPosition();
    }

    public void InstantiateOnlineCar()
    {
        var lastCarKey = PlayerPrefs.GetString(DetailModelView.lastCarBuyKey);

        if (string.IsNullOrEmpty(lastCarKey))
        {
            Debug.LogError("Photon Instantiate");
            var newCar = PhotonNetwork.Instantiate(config.details[0].key, transform.position, Quaternion.identity);
            Car = newCar.GetComponent<PlayerController>();
        }
        else
        {
            Debug.LogError("Photon Instantiate");
            var lastCar = Config.GetDetail(lastCarKey);
            var newCar = PhotonNetwork.Instantiate(lastCar.key, transform.position, Quaternion.identity);
            Car = newCar.GetComponent<PlayerController>();
        }

        SetStartPosition();
    }


    public async void ChangeCar()
    {
        Destroy(Car.gameObject);

        await Task.Delay(300);

        if (!PhotonNetwork.IsConnected)
            StartGame();
        else
            InstantiateOnlineCar();
    }

    public void SetStartPosition()
    {
        Car.transform.position = new Vector3(0, 0, -3);
        Car.transform.rotation = Quaternion.Euler(Vector3.zero);
        Car.CarController.ResetSpeed();
    }
}
