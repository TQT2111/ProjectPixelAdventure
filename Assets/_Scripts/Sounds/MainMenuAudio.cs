using UnityEngine;
using UnityEngine.UI;

public class MainMenuAudio : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource effectAudioSource;
    [SerializeField] private AudioSource musicBackground;
    [Header("Audio Clip")]
    [SerializeField] private AudioClip hoverButton;
    [SerializeField] private AudioClip onClickButton;
    [SerializeField] private AudioClip onClickStart;
    [Header("UI Slider")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider effectSlider;
    void Start()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        effectSlider.onValueChanged.AddListener(SetEffectVolume);
        InitializeSlider();
    }
    private void InitializeSlider()
    {
        effectSlider.value = PlayerPrefs.GetFloat("EffectVolume", 0.5f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        SetEffectVolume(effectSlider.value);
        SetMusicVolume(musicSlider.value);
    }
    public void SetEffectVolume(float volume)
    {
        effectAudioSource.volume = volume;
        PlayerPrefs.SetFloat("EffectVolume", volume);
    }
    public void SetMusicVolume(float volume)
    {
        musicBackground.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    public void PlayHoverButton()
    {
        effectAudioSource.PlayOneShot(hoverButton);
    }
    public void PlayClickButton()
    {
        effectAudioSource.PlayOneShot(onClickButton);
    }
    public void PlayClickStart()
    {
        effectAudioSource.PlayOneShot(onClickStart);
    }
}
