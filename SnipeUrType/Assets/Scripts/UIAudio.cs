using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class UIAudio : MonoBehaviour
{
    public AudioSource effects;
    public AudioClip hover;
    public AudioClip click;

    public void playsound(AudioClip sound)
    {
        effects.PlayOneShot(sound);
    }
}