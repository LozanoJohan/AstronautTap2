using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicAudioSrc;
    [SerializeField] private AudioSource sfxAudioSrc;

    [Header("Music")]
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameMusic;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip HIT;
    [SerializeField] private AudioClip DEATH;
    [SerializeField] private AudioClip GRAB_COIN;
    [SerializeField] private AudioClip CLICK_BTN;

    public static class AudioClips
    {
        // Lista que contendrá los personajes
        public static AudioClip HIT;
        public static AudioClip DEATH;
        public static AudioClip GAB_COIN;
        public static AudioClip CLICK_BTN;
    }

    public static AudioManager I;

    void Awake()
    {
        if (I == null) I = this;

        AudioClips.HIT = HIT;
        AudioClips.DEATH = DEATH;
        AudioClips.GAB_COIN = GRAB_COIN;
    }
    void Start()
    {
        PlayMenuMusic(); // Por defecto se reproduce la musica del menu.
    }
    public void PlayGameMusic()
    {
        musicAudioSrc.clip = gameMusic;
        musicAudioSrc.Play();
    }
    public void PlayMenuMusic()
    {
        musicAudioSrc.clip = menuMusic;
        musicAudioSrc.Play();
    }
    public void MuteMusic()
    {
        musicAudioSrc.mute = true;
    }

    public void UnMuteMusic()
    {
        musicAudioSrc.mute = false;
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxAudioSrc.PlayOneShot(clip);
    }

    public void IncreaseMusicVolume(float value)
    {
        musicAudioSrc.volume += value;
    }
}