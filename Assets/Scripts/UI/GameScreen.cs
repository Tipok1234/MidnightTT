using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text speedText;
    [SerializeField] private TMP_Text currentTimeDriftText;
    [SerializeField] private TMP_Text needDriftTimeLevelText;
    [SerializeField] private TMP_Text addCurencyText;

    [SerializeField] private CurrencyView currencyView;

    [SerializeField] private Button nextLevelButton;

    [SerializeField] private GameObject nextLevelPanel;

    private float lastUpdateTime = 0;
    private float updateInterval = 0.2f;

    private float currentDriftTime = 0;
    private float needDriftTimeLevel = 5;

    private int addCurrency;

    private void Awake()
    {
        nextLevelButton.onClick.AddListener(NextLevelOnClick);
    }
    private void Start()
    {
        PrometeoCarController.CurrentDriftTimeAction += ShowDriftTime;

        ShowDriftTime(0);
        currencyView.SetCurrencyText();
    }

    private void OnDestroy()
    {

        PrometeoCarController.CurrentDriftTimeAction -= ShowDriftTime;
    }

    private void ShowDriftTime(float driftTime)
    {
        currentDriftTime += driftTime;

        if(currentDriftTime >= needDriftTimeLevel)
        {
            NextLevel();
        }

        if (currentTimeDriftText)
            currentTimeDriftText.text = currentDriftTime.ToString("F1") + " sec";

        if (needDriftTimeLevelText)
            needDriftTimeLevelText.text = needDriftTimeLevel.ToString() + " sec";
    }

    public void NextLevel() 
    {
        nextLevelPanel.SetActive(true);
        addCurencyText.text = "10";
        currencyView.AddCurency(10);
    }

    private void NextLevelOnClick()
    {
        nextLevelPanel.SetActive(false);
        currentDriftTime = 0f;
        ShowDriftTime(0);
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
