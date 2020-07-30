using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip titleBGMSong = default;
    [SerializeField] AudioClip shopBGMSong = default;
    protected AudioSource[] audioSources;
    protected AudioSource sfxAudioSource;
    protected AudioSource bgmAudioSource;
    
    public static AudioManager instance;

    public float SFXVolume { get => sfxAudioSource.volume; set => sfxAudioSource.volume = value; }
    public float BGMVolume { get => bgmAudioSource.volume; set => bgmAudioSource.volume = value; }

    public void PlaySoundEffect(AudioClip clipToPlay) => sfxAudioSource.PlayOneShot(clipToPlay);

    public void PlayShopSong()
    {
        bgmAudioSource.clip = shopBGMSong;
        bgmAudioSource.Play();
    }
    public void PlayTitleSong()
    {
        bgmAudioSource.clip = titleBGMSong;
        bgmAudioSource.Play();
    }

    protected void Awake()
    {
        #region Singleton

            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject); //unity is stupid. Needs this to not implode
            instance = this;
        #endregion

        audioSources = GetComponents<AudioSource>();
        sfxAudioSource = audioSources[0];
        bgmAudioSource = audioSources[1];
    }

    protected void Start() => PlayTitleSong();
}
