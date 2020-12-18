using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeValue : MonoBehaviour
{
    [SerializeField]
    private float musicVolume;

    public AudioSource AudioSource;

    public void Start()
    {
        AudioSource.Play();
    }

    public void Update()
    {
        AudioSource.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
