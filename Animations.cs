using UnityEngine;


public class Animations : MonoBehaviour
{
    public static Animations instance;
    private Animator anim;

    private LevelsShopItem levelsShopItem;


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
        anim = GetComponent<Animator>();

        levelsShopItem = FindObjectOfType<LevelsShopItem>();
    }

    private void Start()
    {
        anim.SetBool("Fade", true);
    }

    public void PlayGetHitAnimation()
    {
        anim.SetTrigger("GetHit");
    }

    public void PlayDeathAnimation()
    {
        anim.SetTrigger("Die");
    }

    public void PlayFadeAnimation()
    {
        anim.SetBool("Fade", true);
    }

    public void StopFadeAnimation()
    {
        anim.SetBool("Fade", false);
        levelsShopItem.ActivateLevelButtons();
    }
}
