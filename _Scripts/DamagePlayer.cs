using UnityEngine;
using UnityEngine.EventSystems;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField]
    private int damageAmount = 1;

    [SerializeField]
    private float moveSpeed = 3f;


    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, HealthController.instance.transform.position, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlaySFXAdjusted(0);
            HealthController.instance.DamagePlayer(damageAmount);
            //Animations.instance.PlayGetHitAnimation();
        }
    }
}
