using UnityEngine;

public class CollectablesSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] CollectablePrefab;

    private Vector3 SpawnPos;

    private float minBound_Y = -1f, maxBound_Y = 17f;

    //private float spawnBound_X = 9f;

    private float maxSpawnTime = 0f, minSpawnTime = 2f;

    private float spawnTime;

    private float spawnCounter;

    [SerializeField]
    private float spawnWaitTime = 1f;

    [SerializeField]
    private float thrust = -100f;

    void Start()
    {
        spawnCounter = spawnWaitTime;
    }

    private void FixedUpdate()
    {
        if (!HealthController.instance.isAlive) { return; }
        SpawnCircle();
    }

    private void SpawnCircle()
    {
        if (TimerController.instance.GetCounter() > 100)
        {
            thrust = -300f;
        }
        if (TimerController.instance.GetCounter() > 200)
        {
            thrust = -400f;
        }
        if (TimerController.instance.GetCounter() > 300)
        {
            thrust = -500f;
        }
        if (TimerController.instance.GetCounter() > 400)
        {
            thrust = -600f;
        }
        if (TimerController.instance.GetCounter() > 500)
        {
            thrust = -700f;
        }
        if (TimerController.instance.GetCounter() > 600)
        {
            thrust = -800f;
        }
        if (TimerController.instance.GetCounter() > 700)
        {
            thrust = -900f;
        }
        if (TimerController.instance.GetCounter() > 800)
        {
            thrust = -1000f;
        }
        if (TimerController.instance.GetCounter() > 900)
        {
            thrust = -1100f;
        }

        SpawnPos = new Vector3(transform.position.x, Random.Range(minBound_Y, maxBound_Y));
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        spawnCounter -= Time.deltaTime;

        for (int i = 0; i < CollectablePrefab.Length; i++)
        {

            if (spawnCounter <= 0f)
            {
                int randomCollectables = Random.Range(0, CollectablePrefab.Length);
                GameObject onSceneCollectables = Instantiate(CollectablePrefab[randomCollectables], SpawnPos, Quaternion.identity);
                onSceneCollectables.GetComponent<Rigidbody2D>().AddForce(onSceneCollectables.transform.right * thrust, ForceMode2D.Force);
                spawnCounter = spawnWaitTime;
                if (onSceneCollectables != null)
                {
                    Destroy(onSceneCollectables, 11f);
                }
            }
        }
    }
}
