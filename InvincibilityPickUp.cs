using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityPickUp : MonoBehaviour
{

    [SerializeField]
    private GameObject invincibilityText;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Abilities.instance.isInvincible = true;
            AudioManager.instance.PlaySFXAdjusted(2);
            GameObject instance = Instantiate(invincibilityText, transform.position, Quaternion.identity);
            Destroy(instance, 4f);
            gameObject.SetActive(false);
        }
    }
}
