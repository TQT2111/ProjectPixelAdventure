using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider effectSlider;
    [Header("Audio Source")]
    [SerializeField] private AudioSource musicBackground;
    [SerializeField] private AudioSource effectAudioSource;
    [SerializeField] private float volumeEffectAudio;
    [Header("Audio Clip")]
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip lootingClip;
    [SerializeField] private AudioClip lootHeartClip;
    [SerializeField] private AudioClip takeDameClip;
    [SerializeField] private AudioClip gameOverClip;
    [SerializeField] private AudioClip gameWinClip;
    void Start()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        effectSlider.onValueChanged.AddListener(SetEffectVolume);
        InitializeSliders();
    }

    public void SettingsEffectAudio()
    {
        effectAudioSource.volume = volumeEffectAudio;
    }

    public void PlaySong()
    {

    }
    public void PlayJumpSound()
    {
        effectAudioSource.PlayOneShot(jumpClip);
    }
    public void PlayLootingSound()
    {
        effectAudioSource.PlayOneShot(lootingClip);
    }
    public void PlayLootHeartSound()
    {
        effectAudioSource.PlayOneShot(lootHeartClip);
    }
    public void PlayTakeDameSound()
    {
        effectAudioSource.PlayOneShot(takeDameClip);
    }
    public void PlayGameOverSound()
    {
        effectAudioSource.PlayOneShot(gameOverClip);
    }
    public void PlayGameWinSound()
    {
        effectAudioSource.PlayOneShot(gameWinClip);
    }

    public void InitializeSliders()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        effectSlider.value = PlayerPrefs.GetFloat("EffectVolume", 0.5f);

        SetMusicVolume(musicSlider.value);
        SetEffectVolume(effectSlider.value);
    }

    public void SetMusicVolume(float volume)
    {
        musicBackground.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetEffectVolume(float volume)
    {
        effectAudioSource.volume = volume;
        PlayerPrefs.SetFloat("EffectVolume", volume);
    }
}
