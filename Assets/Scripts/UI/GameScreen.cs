using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text speedText;
    [SerializeField] private TMP_Text currentTimeDriftText;
    [SerializeField] private TMP_Text needDriftTimeLevelText;
    [SerializeField] private TMP_Text addCurencyText;

    [SerializeField] private CurrencyView currencyView;

    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button doubleRewardButton;

    [SerializeField] private GameObject nextLevelPanel;

    private float lastUpdateTime = 0;
    private float updateInterval = 0.2f;

    private float currentDriftTime = 0;
    private float needDriftTimeLevel = 120;

    private int addCurrency;

    public static bool isStopGame;


    //TODO: for movile touch input
    public PrometeoTouchInput throttlePTI;
    public PrometeoTouchInput reversePTI;
    public PrometeoTouchInput turnRightPTI;
    public PrometeoTouchInput turnLeftPTI;
    public PrometeoTouchInput handbrakePTI;

    private void Awake()
    {
        nextLevelButton.onClick.AddListener(NextLevelOnClick);
        doubleRewardButton.onClick.AddListener(DoubleRewardOnClick);
    }

    private void Start()
    {
        PrometeoCarController.CurrentDriftTimeAction += ShowDriftTime;

        ShowDriftTime(0);
        currencyView.SetCurrencyText();
        UpdateTextLevel();
    }

    private void Update()
    {

        if (Time.time - lastUpdateTime >= updateInterval)
        {
            lastUpdateTime = Time.time;

            if (speedText)
            {
                speedText.text = GameManager.Instance.Car.CarController.currentSpeed.ToString();
            }
        }
    }

    private void OnDestroy()
    {

        PrometeoCarController.CurrentDriftTimeAction -= ShowDriftTime;
    }

    private void ShowDriftTime(float driftTime)
    {
        currentDriftTime += driftTime;
        currencyView.AddCurency(Mathf.RoundToInt(driftTime));

        if (currentDriftTime >= needDriftTimeLevel)
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
        isStopGame = true;

        doubleRewardButton.gameObject.SetActive(true);
        nextLevelPanel.SetActive(true);
        addCurrency = 50;
        addCurencyText.text = addCurrency.ToString() + " $";
     
    }

    public void DoubleRewardOnClick()
    {
        GameManager.Instance.AdsManager.ShowRewarded();

        var doubleCurrency = addCurrency * 2;
        addCurencyText.text = doubleCurrency.ToString() + " $";
        addCurrency = doubleCurrency;

        doubleRewardButton.gameObject.SetActive(false);
    }

    private void NextLevelOnClick()
    {
        nextLevelPanel.SetActive(false);
        currentDriftTime = 0f;
        ShowDriftTime(0);
        currencyView.AddCurency(addCurrency);
        isStopGame = false;
        GameSaves.UpdateLevel();
        GameManager.Instance.ChangeCar();
        UpdateTextLevel();
    }

    private void UpdateTextLevel()
    {
        levelText.text = "level: " + (GameSaves.levelIndex + 1).ToString();
    }
}
