using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private Controller ctrl;
    public AudioClip cursor;
    public AudioClip drop;
    public AudioClip control;
    public AudioClip clear;

    private AudioSource audioSource;

    private bool isMute = false;

    private void Awake()
    {
        ctrl = transform.GetComponent<Controller>();
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

    public void PlayControl()
    {
        PlayAudio(control);
    }

    public void PlayClear()
    {
        PlayAudio(clear);
    }

    private void PlayAudio(AudioClip clip)
    {
        if (isMute) return;
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void SetAudioMute()
    {
        isMute = !isMute;
        ctrl.view.SetMuteActive(isMute);
        if(isMute == false)
        {
            PlayCursor();
        }
    }
}
