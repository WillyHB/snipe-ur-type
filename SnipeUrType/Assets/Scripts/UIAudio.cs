using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class UIAudio : MonoBehaviour
{
    public static UIAudio instance;
    public AudioSource effects;
    public AudioClip hover;
    public AudioClip click;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayHover()
    {
        PlaySound(hover);
    }
    public void PlayClick()
    {
        PlaySound(click);
    }
    public void PlaySound(AudioClip sound)
    {
        effects.PlayOneShot(sound);
    }
}