using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource ambientMusic;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else { Destroy(gameObject); }
    }

    public void PlaySFX(AudioClip clip)
    {
        audioSource.volume = Random.Range(0.5f, 0.8f);
        audioSource.pitch = Random.Range(0.8f, 1);
        audioSource.PlayOneShot(clip);
    }


}
