using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get { return instance; } }
    static AudioManager instance;

    AudioSource audi;
    [Header("HUD")]
    [SerializeField] AudioClip buttonClick;
    [Header("Game")]
    [SerializeField] AudioClip coinCollectClip;
    [SerializeField] AudioClip gameWonClip;
    [SerializeField] AudioClip deathClip;
    private void Awake()
    {
        instance = this;
        audi = GetComponent<AudioSource>();
    }
    public void PlayButtonClick()
    {
        audi.clip = buttonClick;
        audi.Play();
    }

    public void PlayCoinCollectClip()
    {
        audi.clip = coinCollectClip;
        audi.Play();
    }

    public void PlayGameWonClip()
    {
        audi.clip = gameWonClip;
        if (!audi.isPlaying)
            audi.Play();
    }

    public void PlayDeadClip()
    {
        audi.clip = deathClip;
        if(!audi.isPlaying)
            audi.Play();
    }
}
