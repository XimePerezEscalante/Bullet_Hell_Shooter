using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    [Header("----------- Audio Source -----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------- Audio Clip -----------")]
    public AudioClip background;
    public AudioClip mainMenu;
    public AudioClip countdownSignal;
    public AudioClip countdownVoice;
    public AudioClip shoot;
    public AudioClip damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
