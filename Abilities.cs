using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    public static Abilities instance;

    [SerializeField]
    private GameObject damageAllCollider;

    [SerializeField]
    private float abilityEffectWaitTime = 1.0f;

    [SerializeField]
    private Button damageAllButton;

    [SerializeField]
    private Image abilityImage;

    [SerializeField]
    private float coolDownTime = 5f;

    private bool isCoolDown;

    private bool isAbilityPressed;

    public bool isInvincible;

    [SerializeField]
    private GameObject invincCol;

    [SerializeField]
    private Collider2D playerCol;

    private float invincLeangth = 5f;

    [SerializeField]
    private float invincCounter;

    [SerializeField]
    private Slider invincSlider;

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
    }

    private void Start()
    {
        abilityImage.fillAmount = 0f;
        invincCounter = invincLeangth;
        invincSlider.maxValue = invincCounter;
    }

    private void Update()
    {
        DamageAllAbility();
        CheckForInvincibility();
    }

    private void CheckForInvincibility()
    {
        if(isInvincible == true)
        {
            invincCol.SetActive(true);
            playerCol.isTrigger = true;
            invincCounter -= Time.deltaTime;
            invincSlider.value = invincCounter;   
            if (invincCounter < 0)
            {
                invincCol.SetActive(false);
                playerCol.isTrigger = false;
                isInvincible = false;
            }

        }
        else
            invincCounter = invincLeangth;
    }

    public bool IsAbillitiesPressed()
    {
        isAbilityPressed = true;
        return isAbilityPressed;
    }


    public void OnAbilityPressed()
    {
        AudioManager.instance.PlaySFX(3);
        damageAllCollider.SetActive(true);
        damageAllButton.interactable = false;

        if (TouchController.instance.isTutorial2On == true)
        {
            TouchController.instance.isTutorialOn = false;
            TouchController.instance.isTutorial2On = false;
            TouchController.instance.StartGameAfterTutorial();
        }

        StartCoroutine(DamageAllAbilityPressed());
    }

    IEnumerator DamageAllAbilityPressed()
    {
        yield return new WaitForSeconds(abilityEffectWaitTime);
        isAbilityPressed = false;
        damageAllCollider.SetActive(false);
    }

    public void DamageAllAbility()
    {
        if(isAbilityPressed == true &&  isCoolDown == false)
        {
            isCoolDown = true;
            abilityImage.fillAmount = 1f;
        }

        if(isCoolDown)
        {
            abilityImage.fillAmount -= 1 / coolDownTime * Time.deltaTime;

            if (abilityImage.fillAmount <= 0f)
            {
                abilityImage.fillAmount = 0f;
                damageAllButton.interactable = true;
                isCoolDown = false;
            }
        }
    }
}
