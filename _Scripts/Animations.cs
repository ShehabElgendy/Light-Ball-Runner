using UnityEngine;


public class Animations : MonoBehaviour
{
    public static Animations instance;
    private Animator anim;


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
    }

    public void PlayGetHitAnimation()
    {
        anim.SetTrigger("GetHit");
    }

    public void PlayDeathAnimation()
    {
        anim.SetTrigger("Die");
    }

}
