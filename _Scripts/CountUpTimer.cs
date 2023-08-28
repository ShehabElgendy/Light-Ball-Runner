//using TMPro;
//using UnityEngine;

//public class CountUpTimer : MonoBehaviour
//{
//    public static CountUpTimer instance;



//    [SerializeField]
//    private TextMeshProUGUI timerText;
//    [SerializeField]
//    private bool fixJumpyText = true;

//    private string timeFormat = "{0,2:00}:{1,2:00}";

//    public bool shouldCount = true;

//    private void Awake()
//    {
//        if (instance != null && instance != this)
//        {
//            Destroy(gameObject);
//        }
//        else
//        {
//            instance = this;
//        }
//        shouldCount = true;
//    }


//    private void FixedUpdate()
//    {
//        if (!shouldCount) { return; }
//        CountTime();

//    }
//    private void CountTime()
//    {
//        int minutes = (int)(Time.timeSinceLevelLoad / 60);
//        int seconds = (int)(Time.timeSinceLevelLoad % 60);
//        int hundredthSeconds = Mathf.RoundToInt((Time.timeSinceLevelLoad - minutes * 60 - seconds) * 100);
//        if (fixJumpyText)
//        {
//            timerText.text = string.Format(timeFormat, minutes, seconds);

//        }
//        else
//        {
//            timerText.text = minutes + ":" + seconds;
//        }
//    }
//}