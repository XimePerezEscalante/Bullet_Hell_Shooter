using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public static Action OnSecondChanged;
    public static Action OnThirtySecondChanged;
    public static Action OnMinuteChanged;
    public static int Second{get; private set;}
    public static int Minute{get; private set;}
    private float minuteToRealTime = 0.5f;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Second = 0;
        timer = minuteToRealTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Second++;

            OnSecondChanged?.Invoke();

            if(Second >= 30)
            {
                OnThirtySecondChanged?.Invoke();
            }
            else if(Second >= 60)
            {
                Minute++;
                OnMinuteChanged?.Invoke();
                Second = 0;
            }

            timer = minuteToRealTime;
        }
    }
}
