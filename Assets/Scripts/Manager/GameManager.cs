using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private DetailsConfig config;
    public PlayerController Car { get; private set; }
    public DetailsConfig Config => config;

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
            Car = Instantiate(lastCar.car,gameObject.transform);
        }

        SetStartPosition();
    }

    public async void ChangeCar()
    {
        Destroy(Car.gameObject);

        await Task.Delay(300);

        StartGame();
    }

    public void SetStartPosition()
    {
        Car.transform.position = new Vector3(0, 0, -3f);
        Car.transform.rotation = Quaternion.Euler(Vector3.zero);

        Car.CarController.ResetSpeed();
    }
}
