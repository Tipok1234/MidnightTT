using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text speedText;
    [SerializeField] private TMP_Text currentTimeDriftText;
    [SerializeField] private TMP_Text needDriftTimeLevelText;

    [SerializeField] private CurrencyView currencyView;

    private float lastUpdateTime = 0;
    private float updateInterval = 0.2f;

    private float currentDriftTime = 0;
    private float needDriftTimeLevel = 120;

    private void Start()
    {
        PrometeoCarController.CurrentDriftTimeAction += ShowDriftTime;

        currencyView.SetCurrencyText();
    }

    private void OnDestroy()
    {

        PrometeoCarController.CurrentDriftTimeAction -= ShowDriftTime;
    }

    private void ShowDriftTime(float driftTime)
    {
        currentDriftTime += driftTime;

        if (currentTimeDriftText)
            currentTimeDriftText.text = currentDriftTime.ToString("F1") + " sec";

        if (needDriftTimeLevelText)
            needDriftTimeLevelText.text = needDriftTimeLevel.ToString() + " sec";
    }

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
