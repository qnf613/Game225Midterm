using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    AudioSource audio;
    public static SoundManager instance;

    public AudioClip jump;
    public AudioClip damaged;
    public AudioClip getBCoin;
    public AudioClip getSCoin;
    public AudioClip getGCoin;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayJump()
    {
        audio.PlayOneShot(jump);
    }

    public void PlayDamaged()
    {

        audio.PlayOneShot(damaged);
    }

    public void PlayGetBCoin()
    {

        audio.PlayOneShot(getBCoin);
    }

    public void PlayGetSCoin()
    {

        audio.PlayOneShot(getSCoin);
    }

    public void PlayGetGCoin()
    {

        audio.PlayOneShot(getGCoin);
    }

}
