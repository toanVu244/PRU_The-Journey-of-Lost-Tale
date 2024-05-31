using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMange : MonoBehaviour
{
    [Header("-----Audio Source-----")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource sfxSource;

    [Header("-----Audio Clips-------")]
    public AudioClip background;
    public AudioClip collectoItem;
    public AudioClip dialogSound;

    private void Start()
    {
        audioSource.clip = background;
        audioSource.Play();
    }

    public void PlayTalkSPX(AudioClip clip)
    {
        sfxSource.pitch = 0.5f;
        sfxSource.PlayOneShot(clip);
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.pitch = 1;
        sfxSource.PlayOneShot(clip);
    }

    public void StopSFX()
    {
        if (sfxSource != null)
        {
            sfxSource.Stop();
        }
    }
}
