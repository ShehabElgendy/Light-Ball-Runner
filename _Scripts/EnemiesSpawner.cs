using Unity.VisualScripting;
using UnityEngine;

public class GarbageSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] garbagePrefab;

    private Vector3 SpawnPos;

    private float minBound_Y = -1f, maxBound_Y = 17f;

    //private float spawnBound_X = 9.5f;

    private float maxSpawnTime = 0f, minSpawnTime = 2f;

    private float spawnTime;

    private float spawnCounter;

    [SerializeField]
    private float spawnWaitTime = 0.5f;

    [SerializeField]
    private float thrust = -100f;


    [SerializeField]
    private float enemiesCount;

    public GameObject onSceneEnemiesToFollow;


    void Start()
    {
        spawnCounter = spawnWaitTime;
        spawnWaitTime = 2f;
        //thrust = -100f;
    }


    private void FixedUpdate()
    {
        if (!HealthController.instance.isAlive || TimerController.instance.GetCounter() < 20) { return; }
        SpawnCircle();
    }

    private void SpawnCircle()
    {
        SpawnPos = new Vector3(transform.position.x, Random.Range(minBound_Y, maxBound_Y));
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        spawnCounter -= Time.deltaTime;


        ////if (TimerController.instance.GetCounter() == Time.time + 10)
        ////{
        ////    spawnWaitTime -= 0.1f;
        ////    thrust -= 100f;
        ////}
        ///

        if (TimerController.instance.GetCounter() > 50)
        {
            spawnWaitTime = 1f;
            //thrust = -300f;
        }
        if (TimerController.instance.GetCounter() > 100)
        {
            spawnWaitTime = 0.5f;
            //thrust = -400f;
        }
        if (TimerController.instance.GetCounter() > 200)
        {
            spawnWaitTime = 0.45f;
            //thrust = -500f;
        }
        if (TimerController.instance.GetCounter() > 300)
        {
            spawnWaitTime = 0.4f;
            //thrust = -600f;
        }
        if (TimerController.instance.GetCounter() > 400)
        {
            spawnWaitTime = 0.35f;
            //thrust = -500f;
        }
        if (TimerController.instance.GetCounter() > 500)
        {
            spawnWaitTime = 0.3f;
            //thrust = -600f;
        }
        if (TimerController.instance.GetCounter() > 600)
        {
            spawnWaitTime = 0.25f;
            //thrust = -700f;
        }
        if (TimerController.instance.GetCounter() > 700)
        {
            spawnWaitTime = 0.2f;
            //thrust = -800f;
        }
        if (TimerController.instance.GetCounter() > 800)
        {
            spawnWaitTime = 0.2f;
            //thrust = -900f;
        }
        if (TimerController.instance.GetCounter() > 900)
        {
            spawnWaitTime = 0.15f;
            //thrust = -1000f;
        }

        for (int i = 0; i < garbagePrefab.Length; i++)

        {

            if (spawnCounter <= 0f)
            {
                int randomEnemy = Random.Range(0, garbagePrefab.Length);
                GameObject onSceneEnemy = Instantiate(garbagePrefab[randomEnemy], SpawnPos, Quaternion.identity);
                onSceneEnemy.GetComponent<Rigidbody2D>().AddForce(onSceneEnemy.transform.right * thrust, ForceMode2D.Force);
                spawnCounter = spawnWaitTime;
                enemiesCount++;
                onSceneEnemiesToFollow = onSceneEnemy;
                if (onSceneEnemy != null)
                {
                    Destroy(onSceneEnemy, 11f);
                }
            }
        }
    }
}
