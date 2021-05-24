using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource mainSource;
    public AudioClip jumpClip;
    public AudioClip bumpClip;
    public AudioClip coinClip;
    public AudioClip winClip;
    public AudioClip dieClip;
    public AudioClip stompClip;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayJump()
    {
        source.Stop();
        source.clip = jumpClip;
        source.Play();
    }

    public void PlayBump()
    {
        source.Stop();
        source.clip = bumpClip;
        source.Play();
    }

    public void PlayCoin()
    {
        source.Stop();
        source.clip = coinClip;
        source.Play();
    }

    public void PlayWin()
    {
        source.Stop();
        source.clip = winClip;
        source.Play();
    }
    public void PlayDie()
    {
        source.Stop();
        source.clip = dieClip;
        source.Play();
    }

    public void PlayStomp()
    {
        source.Stop();
        source.clip = stompClip;
        source.Play();
    }

        public void PauseMain()
    {
        mainSource.Pause();
    }

    public void ResumeMain()
    {
        mainSource.UnPause();
    }

    public void StopSource()
    {
        source.Stop();
    }
}
