using UnityEngine;
using UnityEngine.InputSystem;

public class TouchController : MonoBehaviour
{
    public static TouchController instance;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float speed;

    //[SerializeField]
    //private float minBound_x = 0f, maxBound_x = 0f;

    //[SerializeField]
    //private float minBound_y = -4.8f, maxBound_y = 4.8f;

    private Camera mainCamera;

    public bool canMove = true;

    [SerializeField]
    private GameObject tutorial1;

    [SerializeField]
    private GameObject tutorial2;

    [SerializeField]
    private Transform minBound_x, maxBound_x;

    [HideInInspector]
    public bool isTutorialOn;

    private bool isTutorial1On = true;

    [HideInInspector]
    public bool isTutorial2On = false;

    private int firstTimePlayer;

    [SerializeField]
    private GameObject gamePanel;

    [SerializeField]
    private GameObject pauseScreen;




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
        mainCamera = Camera.main;
        AudioManager.instance.PlayLevelMusic();
        firstTimePlayer = PlayerPrefs.GetInt("TutorialHasPlayed", firstTimePlayer);
    }

    void Update()
    {
        if (pauseScreen.activeSelf) { return; }
        if (HealthController.instance.isAlive && canMove)
        {
            MoveWithTouch();

            if (firstTimePlayer <= 0)
            {
                isTutorialOn = true;
                IsGameStarted();
            }
        }
    }

    private void MoveWithTouch()
    {
        if (!Touchscreen.current.primaryTouch.press.isPressed) { return; }
        Vector3 tempPos = rb.transform.position;




        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

        //Vector2 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);


        tempPos = Vector3.MoveTowards(rb.transform.position, mainCamera.ScreenToWorldPoint(touchPosition), speed);
        Vector3 viewPortPos = mainCamera.WorldToViewportPoint(tempPos);
        //Debug.Log(viewPortPos);
        tempPos.z = 0;



        //if (viewPortPos.x >= 0.7f)
        //{
        //    tempPos.x = maxBound_x;
        //}
        //else if (viewPortPos.x <= 0f)
        //{
        //    tempPos.x = minBound_x;
        //}

        //if (viewPortPos.y >= 0.3f)
        //{
        //    tempPos.y = maxBound_y;
        //}

        //else if (viewPortPos.y <= 0f)
        //{
        //    tempPos.y = minBound_y;
        //}

        //move on X-axis only
        //if (viewPortPos.y != 0)
        //{
        //    tempPos.y = maxBound_y;
        //}
        //else if (viewPortPos.y != 0f)
        //{
        //    tempPos.y = minBound_y;
        //}

        if (tempPos.x < minBound_x.transform.position.x)
        {
            tempPos.x = minBound_x.transform.position.x;
        }
        if (tempPos.x > maxBound_x.transform.position.x)
        {
            tempPos.x = maxBound_x.transform.position.x;
        }

        rb.transform.position = tempPos;
        tempPos.x = rb.transform.position.x + 1.5f;
        rb.transform.position = tempPos;
    }

    public void OnUITouch()
    {
        canMove = false;
    }

    public void OnUILeave()
    {
        canMove = true;
    }

    public void IsGameStarted()
    {

        if (isTutorial1On)
        {
            gamePanel.SetActive(false);
            tutorial1.SetActive(true);
            Time.timeScale = 0.4f;
        }


        if (isTutorialOn)
        {
            if (Touchscreen.current.primaryTouch.press.isPressed && isTutorial1On == true || Input.GetAxisRaw("Horizontal") != 0)
            {
                tutorial1.SetActive(false);
                isTutorial1On = false;
                canMove = true;
            }
            if (Touchscreen.current.primaryTouch.press.isPressed && isTutorial1On == false && isTutorial2On == false && isTutorialOn == true || Input.GetAxisRaw("Horizontal") != 0)
            {
                isTutorial2On = true;
                tutorial2.SetActive(true);
            }
        }

        if ((isTutorial1On == false && isTutorial2On == false && tutorial2.activeSelf) || (Touchscreen.current.primaryTouch.press.isPressed && isTutorial2On == false))
        {
            StartGameAfterTutorial();
        }
    }

    public void StartGameAfterTutorial()
    {
        gamePanel.SetActive(true);
        isTutorialOn = false;
        tutorial2.SetActive(false);
        Time.timeScale = 1f;
        firstTimePlayer++;
        Debug.Log("Start");
        PlayerPrefs.SetInt("TutorialHasPlayed", firstTimePlayer);
    }
}
