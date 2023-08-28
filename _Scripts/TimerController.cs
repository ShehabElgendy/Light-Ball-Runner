using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    [Header("Component")]

    [SerializeField]
    private TextMeshProUGUI timerText;

    [Header("Timer Settings")]

    [SerializeField]
    private float currentTime;

    [SerializeField]
    private bool countDown;

    [Header("Limit Settings")]

    [SerializeField]
    private bool hasLimit;

    [SerializeField]
    private float timerLimit;

    [Header("Format Settings")]

    [SerializeField]
    private bool hasFormat;

    [SerializeField]
    private TimerFormats format;

    private Dictionary<TimerFormats, string> timeFormats = new();

    //[SerializeField]
    //private float counterWaitTime = 10f;


    [SerializeField]
    private GameObject mileStoneEffectorPref;

    private TouchController touchController;

    private int mileStoneCheckPoints = 0;

    private float mileStoneLenght = 100;

    [SerializeField]
    private float mileStoneCountDown;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        touchController = FindObjectOfType<TouchController>();
    }

    void Start()
    {
        timeFormats.Add(TimerFormats.Whole, "0");
        timeFormats.Add(TimerFormats.TensDecimal, "0.0");
        timeFormats.Add(TimerFormats.HundredthDecimal, "0.00");
        mileStoneCheckPoints = 0;
        mileStoneCountDown = mileStoneLenght;
    }

    void Update()
    {
        if (HealthController.instance.isAlive && touchController.isTutorialOn == false)
        {
            currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime * 3f;

            if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
            {
                currentTime = timerLimit;
                SetTimerText();
                timerText.color = Color.red;
                enabled = false;
            }
            SetTimerText();

            mileStoneCountDown -= Time.deltaTime * 3f;

            InstentiateMileStones1();
            InstentiateMileStones2();
            InstentiateMileStones3();
            InstentiateMileStones4();
            InstentiateMileStones5();
            InstentiateMileStones6();
            InstentiateMileStones7();
            InstentiateMileStones8();
            InstentiateMileStones9();
            InstentiateMileStones10();
        }
    }


    private void SetTimerText()
    {
        timerText.text = hasFormat ? currentTime.ToString(timeFormats[format]) : currentTime.ToString();
    }

    public int GetCounter()
    {
        return (int)(currentTime);
    }

    public int ResetCounter()
    {
        currentTime = 0;
        return (int)(currentTime);
    }

    private void InstentiateMileStones1()
    {
        if (mileStoneCountDown <= 0f)
        {
            mileStoneCheckPoints = 1;
            if (mileStoneCheckPoints == 1)
            {
                GameObject mileStoneInstance = Instantiate(mileStoneEffectorPref, transform.position, Quaternion.identity);
                Destroy(mileStoneInstance, 10f);
            }
            mileStoneCountDown = mileStoneLenght;

        }
    }
    private void InstentiateMileStones2()
    {
        if (mileStoneCountDown <= 0f)
        {
            mileStoneCheckPoints = 2;
            if (mileStoneCheckPoints == 2)
            {
                GameObject mileStoneInstance = Instantiate(mileStoneEffectorPref, transform.position, Quaternion.identity);
                Destroy(mileStoneInstance, 10f);
            }
            mileStoneCountDown = mileStoneLenght;

        }
    }
    private void InstentiateMileStones3()
    {
        if (mileStoneCountDown <= 0f)
        {
            mileStoneCheckPoints = 3;
            if (mileStoneCheckPoints == 3)
            {
                GameObject mileStoneInstance = Instantiate(mileStoneEffectorPref, transform.position, Quaternion.identity);
                Destroy(mileStoneInstance, 10f);
            }
            mileStoneCountDown = mileStoneLenght;

        }
    }
    private void InstentiateMileStones4()
    {
        if (mileStoneCountDown <= 0f)
        {
            mileStoneCheckPoints = 4;
            if (mileStoneCheckPoints == 4)
            {
                GameObject mileStoneInstance = Instantiate(mileStoneEffectorPref, transform.position, Quaternion.identity);
                Destroy(mileStoneInstance, 10f);
            }
            mileStoneCountDown = mileStoneLenght;

        }
    }
    private void InstentiateMileStones5()
    {
        if (mileStoneCountDown <= 0f)
        {
            mileStoneCheckPoints = 5;
            if (mileStoneCheckPoints == 5)
            {
                GameObject mileStoneInstance = Instantiate(mileStoneEffectorPref, transform.position, Quaternion.identity);
                Destroy(mileStoneInstance, 10f);
            }
            mileStoneCountDown = mileStoneLenght;

        }
    }
    private void InstentiateMileStones6()
    {
        if (mileStoneCountDown <= 0f)
        {
            mileStoneCheckPoints = 6;
            if (mileStoneCheckPoints == 6)
            {
                GameObject mileStoneInstance = Instantiate(mileStoneEffectorPref, transform.position, Quaternion.identity);
                Destroy(mileStoneInstance, 10f);
            }
            mileStoneCountDown = mileStoneLenght;

        }
    }
    private void InstentiateMileStones7()
    {
        if (mileStoneCountDown <= 0f)
        {
            mileStoneCheckPoints = 7;
            if (mileStoneCheckPoints == 7)
            {
                GameObject mileStoneInstance = Instantiate(mileStoneEffectorPref, transform.position, Quaternion.identity);
                Destroy(mileStoneInstance, 10f);
            }
            mileStoneCountDown = mileStoneLenght;

        }
    }
    private void InstentiateMileStones8()
    {
        if (mileStoneCountDown <= 0f)
        {
            mileStoneCheckPoints = 8;
            if (mileStoneCheckPoints == 8)
            {
                GameObject mileStoneInstance = Instantiate(mileStoneEffectorPref, transform.position, Quaternion.identity);
                Destroy(mileStoneInstance, 10f);
            }
            mileStoneCountDown = mileStoneLenght;

        }
    }
    private void InstentiateMileStones9()
    {
        if (mileStoneCountDown <= 0f)
        {
            mileStoneCheckPoints = 9;
            if (mileStoneCheckPoints == 9)
            {
                GameObject mileStoneInstance = Instantiate(mileStoneEffectorPref, transform.position, Quaternion.identity);
                Destroy(mileStoneInstance, 10f);
            }
            mileStoneCountDown = mileStoneLenght;

        }
    }
    private void InstentiateMileStones10()
    {
        if (mileStoneCountDown <= 0f)
        {
            mileStoneCheckPoints = 10;
            if (mileStoneCheckPoints == 10)
            {
                GameObject mileStoneInstance = Instantiate(mileStoneEffectorPref, transform.position, Quaternion.identity);
                Destroy(mileStoneInstance, 10f);
            }
            mileStoneCountDown = mileStoneLenght;

        }
    }
}



public enum TimerFormats
{
    Whole,
    TensDecimal,
    HundredthDecimal
}