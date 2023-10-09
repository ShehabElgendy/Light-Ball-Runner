using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 7f;

    [SerializeField]
    private int damageAmount = 1;

    [SerializeField]
    private GameObject explosionEffect;

    private Rigidbody2D rb;

    private Vector3 moveDirection;

    private GameObject targetToFollow;

    private bool isActive;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        AudioManager.instance.PlaySFXAdjusted(4);
        FindClosestEnemyWithTag();
        CheckForActiveStatus();
    }

    private void FixedUpdate()
    {
        MoveBullet();

    }

    private void MoveBullet()
    {
        if (FindClosestEnemyWithTag() != null)
        {
            moveDirection = (targetToFollow.transform.position - transform.position).normalized * moveSpeed;
            rb.MovePosition(rb.transform.position + moveDirection * moveSpeed * Time.deltaTime);

        }
        else
        {

            rb.MovePosition(rb.transform.position + moveDirection * moveSpeed * Time.deltaTime);
            rb.isKinematic = true;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != null && this.gameObject != null)
        {
            if (collision.gameObject.CompareTag("Enemies"))
            {
                isActive = false;
                collision.GetComponent<EnemyHealthController>().DamageEnemy(damageAmount);
                if (explosionEffect != null)
                {
                    Instantiate(explosionEffect, transform.position, Quaternion.identity);
                }
                gameObject.SetActive(false);
            }
        }
        if (collision.IsTouchingLayers(8))
        {
            Destroy(gameObject);
        }

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public GameObject FindClosestEnemyWithTag()
    {
        if (!isActive)
        {
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("Enemies");
            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }

                targetToFollow = closest;
                isActive = true;

            }

        }
        return targetToFollow;
    }


    public bool CheckForActiveStatus()
    {
        return isActive;
    }

    public float SetMoveSpeed()
    {
        moveSpeed = 7f;

        return moveSpeed;
    }


    public float IncreaseMoveSpeed(float amount)
    {
        if (moveSpeed >= 5)
        {
            moveSpeed += amount;
        }
        else if (moveSpeed >= 9) 
        {
            moveSpeed = 9;
        }

        return moveSpeed;
    }

    public float DecreaseMoveSpeed(float amount)
    {
        if (moveSpeed > 5)
        {
            moveSpeed -= amount;
        }
        else if (moveSpeed <= 5)
        {
            moveSpeed = 5f;
        }

        return moveSpeed;
    }


    ///// Use this method to get all loaded objects of some type, including inactive objects. 
    ///// This is an alternative to Resources.FindObjectsOfTypeAll (returns project assets, including prefabs), and GameObject.FindObjectsOfTypeAll (deprecated).

    //public static List<DamageCat> FindObjectsOfTypeAll<DamageCat>()
    //{
    //    List<DamageCat> results = new();

    //    for (int i = 0; i < SceneManager.sceneCount; i++)
    //    {
    //        var s = SceneManager.GetSceneAt(i);
    //        if (s.isLoaded)
    //        {
    //            var allGameObjects = s.GetRootGameObjects();
    //            for (int j = 0; j < allGameObjects.Length; j++)
    //            {
    //                var go = allGameObjects[j];
    //                results.AddRange(go.GetComponentsInChildren<DamageCat>(true));
    //            }
    //        }
    //    }

    //    return results;
    //}


}
