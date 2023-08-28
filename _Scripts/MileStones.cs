using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MileStones : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI mileStoneText;

    private void Update()
    {
        mileStoneText.text = TimerController.instance.GetCounter().ToString();
    }
}
