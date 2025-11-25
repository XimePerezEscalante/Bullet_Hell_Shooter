using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CountdownController : MonoBehaviour
{
    AudioSystem audioSystem;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSystem = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSystem>();
        audioSystem.PlaySFX(audioSystem.countdownVoice);
        audioSystem.PlaySFX(audioSystem.countdownSignal);
    }

    public void OnAnimationFinished()
    {
        Destroy(gameObject);
    }
}
