using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float timer = 0;
    float MaxTime = 100f;

    public bool isStart = false;

    [SerializeField]
    UIManager UI_manager;

    [SerializeField]
    ProcessScreen PS_screen;

    [SerializeField]
    SmartCityScreen SCS_screen;

    [SerializeField]
    MainScreen M_Screen;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.touchCount > 0)
        {
            timer = 0;
        }
        if (isStart && timer > MaxTime)
        {
            UI_manager.ShowMainScreen();
            SCS_screen.InitSmartCityScreen();
            PS_screen.InitProcessScreen();
            AudioManager.StopSound();
            isStart = false;
            timer = 0;
        }
    }
}
