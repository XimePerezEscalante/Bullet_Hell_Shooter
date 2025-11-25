using UnityEngine;
using System;

public class BulletManager : MonoBehaviour
{
    public static int mermaidBulletCount{get; private set;}
    public static int gorgonBulletCount{get; private set;}

    public static Action OnChangedMermaidBulletCount;
    public static Action OnChangedGorgonBulletCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mermaidBulletCount = 0;
        mermaidBulletCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Mermaid Bullet Count" + mermaidBulletCount);
    }

    public static void ChangeMermaidBulletCount(bool increase)
    {
        if (increase) {
            mermaidBulletCount += 1;
        }
        else
        {
            mermaidBulletCount -= 1;
        }

        OnChangedMermaidBulletCount.Invoke();
    }

    public static void ChangeGorgonBulletCount(bool increase)
    {
        if (increase) {
            gorgonBulletCount += 1;
        }
        else
        {
            gorgonBulletCount -= 1;
        }

        OnChangedMermaidBulletCount.Invoke();
    }
}
