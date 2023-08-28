using UnityEngine;
using TMPro;

public class FirePowerUp : MonoBehaviour
{
    private FindClosestEnemy findClosestEnemy;
    //private BulletController bulletController;

    [SerializeField]
    private float increaseAmount = 0.05f;

    [SerializeField]
    private float increaseMoveSpeedAmount = 1f;

    [SerializeField]
    private GameObject bulletPrefab;
    
    [SerializeField]
    private GameObject firePowerUpText;

    private void Awake()
    {
        findClosestEnemy = FindObjectOfType<FindClosestEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bulletPrefab.GetComponent<BulletController>().IncreaseMoveSpeed(increaseMoveSpeedAmount);
            findClosestEnemy.FirePowerUp(increaseAmount);
            AudioManager.instance.PlaySFXAdjusted(2);
            GameObject instance = Instantiate(firePowerUpText, transform.position, Quaternion.identity);
            Destroy(instance, 4f );
            gameObject.SetActive(false);
        }
    }

}
