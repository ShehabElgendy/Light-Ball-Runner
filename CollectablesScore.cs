using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CollectablesScore : MonoBehaviour
{
    private ScoreController scoreController;

    [SerializeField]
    private int score = 1;

    [SerializeField]
    private GameObject diamondPickUpText;

    private void Awake()
    {
        scoreController = FindObjectOfType<ScoreController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlaySFXAdjusted(1);
            GameObject instance = Instantiate(diamondPickUpText, transform.position, quaternion.identity);
            scoreController.ModifyScore(score);
            gameObject.SetActive(false);
        }
    }
}
