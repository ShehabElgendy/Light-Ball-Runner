using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public static HealthController instance;

    private GameOverController gameOverPanel;


    [SerializeField]
    private CircleCollider2D circleCol;

    //[SerializeField]
    //private Image[] healthImg;

    //[SerializeField]
    //private Sprite fullHealth, emptyHealth;

    [SerializeField]
    SpriteRenderer[] playerSprites;

    [SerializeField]
    private float invincibilityLength;

    private float invincCounter;

    [SerializeField]
    private float flashLength;

    private float flashCounter;

    [SerializeField]
    private int currentHealth = 0;

    [SerializeField]
    private int maxHealth = 3;

    public bool isAlive = true;

    private bool isDamaged;

    private ScoreUIDisplay UIDisplay;

    private FindClosestEnemy findClosestEnemy;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private GameObject playerLight;

    [SerializeField]
    private GameObject playerLight1;

    private CarMoveForward movingScene;

    private float decreaseFireRateAmount = 0.01f;

    private float decreaseMoveSpeedAmount = 0.2f;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        gameOverPanel = FindObjectOfType<GameOverController>();
        findClosestEnemy = FindObjectOfType<FindClosestEnemy>();
        UIDisplay = FindObjectOfType<ScoreUIDisplay>();
        movingScene = FindObjectOfType<CarMoveForward>();
    }

    void Start()
    {
        isAlive = true;
        isDamaged = false;
        currentHealth = maxHealth;

    }

    private void Update()
    {
        CheckForDamage();
    }

    private void CheckForDamage()
    {
        if (invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                foreach (SpriteRenderer sr in playerSprites)
                {
                    sr.enabled = !sr.enabled;
                }
                flashCounter = flashLength;
            }

            if (invincCounter <= 0)
            {
                foreach (SpriteRenderer sr in playerSprites)
                {
                    sr.enabled = true;
                }
                flashCounter = 0f;
            }
        }

        //foreach (Image img in healthImg)
        //{
        //    img.sprite = emptyHealth;
        //}
        //for (int i = 0; i < currentHealth; i++)
        //{
        //    healthImg[i].sprite = fullHealth;
        //}
    }

    public void AddHealth()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth++;
        }
    }


    public void DamagePlayer(int damageAmount)
    {
        isDamaged = true;
        if (invincCounter <= 0)
        {
            currentHealth -= damageAmount;

            findClosestEnemy.DecreaseFireAndSpeed(decreaseFireRateAmount);
            bulletPrefab.GetComponent<BulletController>().DecreaseMoveSpeed(decreaseMoveSpeedAmount);

#if !UNITY_EDITOR
            Handheld.Vibrate();
#endif
            if (currentHealth <= 0)
            {
                currentHealth = 0;
            }
            else
            {
                invincCounter = invincibilityLength;
                isDamaged = false;
            }
        }
        if (currentHealth <= 0)
        {
            isAlive = false;
            //Animations.instance.PlayDeathAnimation();
            Die();
            circleCol.enabled = false;
        }
    }

    public void Die()
    {
        playerLight.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(true);
        gameOverPanel.EndGame();
        gameObject.SetActive(false);
    }

    public void Revive()
    {
        gameObject.SetActive(true);
        playerLight.gameObject.SetActive(true);
        playerLight1.gameObject.SetActive(true);
        CheckForDamage();
        Abilities.instance.OnAbilityPressed();
        transform.position = TimerController.instance.transform.position;
        circleCol.enabled = true;
        currentHealth = 3;
    }

    public void FillHealth()
    {
        currentHealth = maxHealth;

        UIDisplay.UpdateHealth(currentHealth, maxHealth);
    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIDisplay.UpdateHealth(currentHealth, maxHealth);
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }    
    
    public int GetMaxHealth()
    {
        return maxHealth;
    }
}

