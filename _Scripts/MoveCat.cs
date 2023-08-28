using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCat : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed_x = 8f, moveSpeed_y = 8f;

    [SerializeField]
    private Transform minBound_x, maxBound_x;

    [SerializeField]
    private float minBound_y, maxBound_y;

    private Vector3 tempPos;

    private Camera mainCamera;



    private void Awake()
    {
        Application.targetFrameRate = 60;
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (!HealthController.instance.isAlive)
            return;
        Move();
        //KeepCatOnScreen();
    }
    public void Move()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        tempPos = transform.position;

        if (h != 0f)
        {
            tempPos.x += h * moveSpeed_x * Time.deltaTime;
            if (tempPos.x < minBound_x.transform.position.x)
            {
                tempPos.x = minBound_x.transform.position.x;
            }
            if (tempPos.x > maxBound_x.transform.position.x)
            {
                tempPos.x = maxBound_x.transform.position.x;
            }
        }

        if (v != 0f)
        {
            tempPos.y += v * moveSpeed_y * Time.deltaTime;
            if (tempPos.y < minBound_y)
            {
                tempPos.y = minBound_y;
            }
            if (tempPos.y > maxBound_y)
            {
                tempPos.y = maxBound_y;
            }
        }

        transform.position = tempPos;
    }

    private void KeepCatOnScreen()
    {
        Vector3 newPos = transform.position;
        Vector3 viewPortPos = mainCamera.WorldToViewportPoint(newPos);

        if (viewPortPos.x > 1.1f)
        {
            newPos.x = -newPos.x + 0.1f;
        }
        else if (viewPortPos.x < -0.1f)
        {
            newPos.x = -newPos.x -0.1f;
        }

        transform.position = newPos;
    }
}


