using Unity.Mathematics;
using UnityEngine;

public class AddHealth : MonoBehaviour
{

    [SerializeField]
    private GameObject healthPickUpText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlaySFXAdjusted(2);
            GameObject instance = Instantiate(healthPickUpText, transform.position, quaternion.identity);
            Destroy(instance, 4f);
            HealthController.instance.AddHealth();
            gameObject.SetActive(false);
        }
    }
}
