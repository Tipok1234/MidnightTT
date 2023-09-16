using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private PlayerController carModel;
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
        Car = Instantiate(carModel, gameObject.transform);
        Car.transform.position = Vector3.zero;
    }
}
