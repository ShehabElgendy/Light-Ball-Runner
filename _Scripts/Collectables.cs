using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool hasTarget;

    private Vector3 targetPos;

    [SerializeField]
    private float magnetSpeed = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (hasTarget)
        {
            Vector2 targetDir = (targetPos - transform.position).normalized;
            rb.velocity = new Vector2(targetDir.x, targetDir.y) * magnetSpeed;
        }
    }

    public void SetTarget(Vector3 position)
    {

        targetPos = position;
        hasTarget = true;
    }
}
