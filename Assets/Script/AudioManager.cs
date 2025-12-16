using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Singleton pattern - agar AudioManager bisa diakses dari script manapun
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;    // Untuk background music
    public AudioSource sfxSource;      // Untuk sound effects

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;  // Lagu untuk Main Menu dan Gameplay
    public AudioClip wolfDeathSFX;     // Sound effect serigala mati

    void Awake()
    {
        // Singleton pattern - hanya ada 1 AudioManager di scene
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Jangan hancurkan saat pindah scene
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        // Mainkan background music saat game mulai
        PlayBackgroundMusic();
    }

    // Fungsi untuk memutar background music
    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null && musicSource != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;  // Loop agar terus berulang
            musicSource.volume = 0.5f; // Volume 50%
            musicSource.Play();
        }
    }

    // Fungsi untuk stop background music
    public void StopBackgroundMusic()
    {
        if (musicSource != null)
        {
            musicSource.Stop();
        }
    }

    // Fungsi untuk memutar sound effect serigala mati
    public void PlayWolfDeathSFX()
    {
        if (wolfDeathSFX != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(wolfDeathSFX);
        }
    }

    // Fungsi untuk memutar sound effect lainnya (jika nanti mau tambah)
    public void PlaySFX(AudioClip clip)
    {
        if (clip != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    // Fungsi untuk mengatur volume music
    public void SetMusicVolume(float volume)
    {
        if (musicSource != null)
        {
            musicSource.volume = volume;
        }
    }

    // Fungsi untuk mengatur volume SFX
    public void SetSFXVolume(float volume)
    {
        if (sfxSource != null)
        {
            sfxSource.volume = volume;
        }
    }
}
