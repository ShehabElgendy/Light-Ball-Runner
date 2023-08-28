using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField]
    private int totalHealth = 3;

    private Collider2D col;

    [SerializeField]
    private GameObject enemyDeathEffect;


    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    public void DamageEnemy(int damageAmount)
    {
        totalHealth -= damageAmount;

        if (totalHealth <= 0)
        {
            InstantiateDeathEffect();
            col.enabled = false;
            AudioManager.instance.PlaySFX(5);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("InvincibilityCollider"))
        {
            AudioManager.instance.PlaySFX(5);
            Destroy(gameObject);
        }
    }

    public void InstantiateDeathEffect()
    {
        if (enemyDeathEffect != null)
        {
            Instantiate(enemyDeathEffect, transform.position, transform.rotation);
        }
    }
}
