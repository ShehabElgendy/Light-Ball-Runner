using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.PlayMainMenuMusic();
    }
}
