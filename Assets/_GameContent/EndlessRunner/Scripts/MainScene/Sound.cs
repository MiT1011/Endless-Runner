using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound{
    public string audioName;
    public AudioClip clip;
    public float volume;
    public bool loop;
    public AudioSource audioSource;
}