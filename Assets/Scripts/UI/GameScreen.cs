using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text speedText;

    private float lastUpdateTime = 0;
    private float updateInterval = 0.2f; 

    private void Update()
    {
        if (Time.time - lastUpdateTime >= updateInterval)
        {
            lastUpdateTime = Time.time;

            if (speedText)
            {
                speedText.text = GameManager.Instance.Car.currentSpeed.ToString();
            }
        }
    }
}
