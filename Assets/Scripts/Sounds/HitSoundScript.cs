using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSoundScript : MonoBehaviour
{
    private AudioSource m_AudioSource;


    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        Debug.Log("Sound played");
        m_AudioSource.clip = clip;
        m_AudioSource.Play();
    }
}
