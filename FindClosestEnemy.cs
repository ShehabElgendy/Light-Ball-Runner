using UnityEngine;

public class FindClosestEnemy : MonoBehaviour
{

    [SerializeField]
    private GameObject bulletPrefab1, bulletPrefab2, bulletPrefab3, bulletPrefab4;

    [SerializeField]
    private Transform gunPos1, gunPos2, gunPos3, gunPos4;

    [SerializeField]
    private float fireWaitTime1, fireWaitTime2, fireWaitTime3, fireWaitTime4;

    private GameObject bullet1, bullet2, bullet3, bullet4;

    private GameObject targetToFollow;

    private EnemiesSpawner garbageSpawner;

    private float nextFireTime1, nextFireTime2, nextFireTime3, nextFireTime4;

    private LevelsManager upgradesManager;

    private void Awake()
    {
        garbageSpawner = FindObjectOfType<EnemiesSpawner>();
    }
    private void Start()
    {
        bulletPrefab1.GetComponent<BulletController>().SetMoveSpeed();
        bulletPrefab2.GetComponent<BulletController>().SetMoveSpeed();
        bulletPrefab3.GetComponent<BulletController>().SetMoveSpeed();
        bulletPrefab4.GetComponent<BulletController>().SetMoveSpeed();

        nextFireTime1 = fireWaitTime1;
        nextFireTime2 = fireWaitTime2;
        nextFireTime3 = fireWaitTime3;
        nextFireTime4 = fireWaitTime4;
    }

    private void Update()
    {
        if (garbageSpawner.onSceneEnemiesToFollow != null && HealthController.instance.isAlive)
        {
            if (TimerController.instance.GetCounter() > 5)
            {
                FindClosestEnemiesForBullet1();

                if (PlayerPrefs.GetInt("_Upgrade" + 0, 0) == 1)
                {
                    FindClosestEnemiesForBullet2();

                }
                if (PlayerPrefs.GetInt("_Upgrade" + 1, 0) == 1)
                {
                    FindClosestEnemiesForBullet3();
                }
                if (PlayerPrefs.GetInt("_Upgrade" + 2, 0) == 1)
                {
                    FindClosestEnemiesForBullet4();
                }


                nextFireTime1 -= Time.deltaTime;
                nextFireTime2 -= Time.deltaTime;
                nextFireTime3 -= Time.deltaTime;
                nextFireTime4 -= Time.deltaTime;
            }
        }
    }



    private void FindClosestEnemiesForBullet1()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        DamagePlayer closestEnemy = null;
        DamagePlayer[] allEnemies = GameObject.FindObjectsOfType<DamagePlayer>();

        foreach (DamagePlayer currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - gunPos1.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }

            Debug.DrawLine(gunPos1.transform.position, closestEnemy.transform.position);

            if (nextFireTime1 <= 0)
            {
                bullet1 = Instantiate(bulletPrefab1, gunPos1.transform.position, Quaternion.identity);
                nextFireTime1 = fireWaitTime1;
            }
        }
    }

    private void FindClosestEnemiesForBullet2()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        DamagePlayer closestEnemy = null;
        DamagePlayer[] allEnemies = GameObject.FindObjectsOfType<DamagePlayer>();

        foreach (DamagePlayer currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - gunPos1.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
            if (nextFireTime2 <= 0)
            {
                bullet2 = Instantiate(bulletPrefab2, gunPos2.transform.position, Quaternion.identity);
                nextFireTime2 = fireWaitTime2;
            }
        }
    }

    private void FindClosestEnemiesForBullet3()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        DamagePlayer closestEnemy = null;
        DamagePlayer[] allEnemies = GameObject.FindObjectsOfType<DamagePlayer>();

        foreach (DamagePlayer currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - gunPos1.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
            if (nextFireTime3 <= 0)
            {
                bullet3 = Instantiate(bulletPrefab3, gunPos3.transform.position, Quaternion.identity);
                nextFireTime3 = fireWaitTime3;
            }
        }
    }

    private void FindClosestEnemiesForBullet4()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        DamagePlayer closestEnemy = null;
        DamagePlayer[] allEnemies = GameObject.FindObjectsOfType<DamagePlayer>();

        foreach (DamagePlayer currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - gunPos1.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
            if (nextFireTime4 <= 0)
            {
                bullet4 = Instantiate(bulletPrefab4, gunPos4.transform.position, Quaternion.identity);
                nextFireTime4 = fireWaitTime4;
            }
        }
    }

    public void FirePowerUp(float increaseAmount)
    {
        if (fireWaitTime1 > 0.5f)
        {
            fireWaitTime1 -= increaseAmount;
            fireWaitTime2 -= increaseAmount;
            fireWaitTime3 -= increaseAmount;
            fireWaitTime4 -= increaseAmount;
        }
        else
        {
            fireWaitTime1 = 0.5f;
            fireWaitTime2 = 0.5f;
            fireWaitTime3 = 0.5f;
            fireWaitTime4 = 0.5f;
        }
    }



    public void DecreaseFireAndSpeed(float decreaseFireRateAmount)
    {
        if (fireWaitTime1 < 1f)
        {
            fireWaitTime1 += decreaseFireRateAmount;
            fireWaitTime2 += decreaseFireRateAmount;
            fireWaitTime3 += decreaseFireRateAmount;
            fireWaitTime4 += decreaseFireRateAmount;
        }
        else
        {
            fireWaitTime1 = 1f;
            fireWaitTime2 = 1.01f;
            fireWaitTime3 = 1.02f;
            fireWaitTime4 = 1.03f;
        }

    }
}
