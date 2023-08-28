using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DamageAllEnemies : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D circleCollider;

    [SerializeField]
    private float colliderExpansionWaitTime = 0.8f;

    [SerializeField]
    private float expantionMagnitude = 0.02f;

    [SerializeField]
    private GameObject explosionEffect;

    [SerializeField]
    private Light2D explosionLight;



    private void FixedUpdate()
    {
        if (Abilities.instance.IsAbillitiesPressed())
        {
            circleCollider.radius += expantionMagnitude;
            explosionLight.pointLightOuterRadius += expantionMagnitude;
            StartCoroutine(SetColliderRadius());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<DamagePlayer>(out DamagePlayer onSceneEnemy))
        {
            AudioManager.instance.PlaySFX(5);
            onSceneEnemy.gameObject.SetActive(false);
            Instantiate(explosionEffect, onSceneEnemy.transform.position, Quaternion.identity);
        }
        if (collision.gameObject.TryGetComponent<BulletController>(out BulletController onSceneBullets))
        {
            onSceneBullets.gameObject.SetActive(false);
        }
    }

    IEnumerator SetColliderRadius()
    {
        yield return new WaitForSeconds(colliderExpansionWaitTime);
        circleCollider.radius = 0.1f;
        explosionLight.pointLightOuterRadius = 0.1f;
    }

}
