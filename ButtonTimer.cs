using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTimer : MonoBehaviour
{
    public Button button;
    private const float ONE_HOUR = 60 * 60;

    private void Start()
    {
        if (button.interactable == true)
        {
            button.GetComponentInChildren<TextMeshProUGUI>().text = "+200";
        }

        // Check if the button should be disabled on start
        if (PlayerPrefs.HasKey("lastClicked"))
        {
            float timeElapsed = (float)(DateTime.Now - DateTime.FromBinary(Convert.ToInt64(PlayerPrefs.GetString("lastClicked")))).TotalSeconds;
            if (timeElapsed < ONE_HOUR)
            {
                // Disable the button
                button.interactable = false;

                // Set a coroutine to update the timer text
                StartCoroutine(UpdateTimer(ONE_HOUR - timeElapsed));
            }
        }
    }

    private void LateUpdate()
    {
        if(gameObject.activeSelf)
        {
            // Check if the button should be disabled on start
            if (PlayerPrefs.HasKey("lastClicked"))
            {
                float timeElapsed = (float)(DateTime.Now - DateTime.FromBinary(Convert.ToInt64(PlayerPrefs.GetString("lastClicked")))).TotalSeconds;
                if (timeElapsed < ONE_HOUR)
                {
                    // Disable the button
                    button.interactable = false;

                    // Set a coroutine to update the timer text
                    StartCoroutine(UpdateTimer(ONE_HOUR - timeElapsed));
                }
            }
        }
    }

    IEnumerator UpdateTimer(float delay)
    {
        while (delay > 0)
        {
            // Update the timer text
            int minutes = Mathf.FloorToInt(delay / 60);
            int seconds = Mathf.FloorToInt(delay % 60);
            button.GetComponentInChildren<TextMeshProUGUI>().text = string.Format("{0:00}:{1:00}", minutes, seconds);

            yield return new WaitForSeconds(1);
            delay -= 1;
        }

        // Re-enable the button and clear the timer text
        button.interactable = true;
    }
}