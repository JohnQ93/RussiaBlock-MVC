using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip cursor;
    public AudioClip drop;

    private AudioSource audioSource;

    private bool isMute = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCursor()
    {
        PlayAudio(cursor);
    }

    public void PlayDrop()
    {
        PlayAudio(drop);
    }

    private void PlayAudio(AudioClip clip)
    {
        if (isMute) return;
        audioSource.clip = clip;
        audioSource.Play();
    }
}
