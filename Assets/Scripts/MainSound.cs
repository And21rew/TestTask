using UnityEngine;
using UnityEngine.UI;

public class MainSound : MonoBehaviour
{
    [SerializeField] private Slider soundSlider, musicSlider;
    [SerializeField] private Text soundSliderHandleText, musicSliderHandleText;
    [SerializeField] private AudioSource soundSource, musicSource;

    private void Start()
    {
        InitializeFirstMusicSoundVolume();
        SetSlidersValue();
        SetSliderHandleValue();
        AudioSourcesSetValue();
    }

    private void Update()
    {
        if (soundSlider.value != soundSource.volume || musicSlider.value != musicSource.volume)
        {
            SaveAudioValue();
            SetSliderHandleValue();
            AudioSourcesSetValue();
        }
    }

    private void InitializeFirstMusicSoundVolume()
    {
        if (!PlayerPrefs.HasKey("musicvolume"))
            PlayerPrefs.SetInt("musicvolume", 5);

        if (!PlayerPrefs.HasKey("soundvolume"))
            PlayerPrefs.SetInt("soundvolume", 5);
    }

    private void SetSlidersValue()
    {
        musicSlider.value = PlayerPrefs.GetInt("musicvolume");
        soundSlider.value = PlayerPrefs.GetInt("soundvolume");
    }

    private void SetSliderHandleValue()
    {
        soundSliderHandleText.text = soundSlider.value.ToString();
        musicSliderHandleText.text = musicSlider.value.ToString();
    }

    private void AudioSourcesSetValue()
    {
        musicSource.volume = (float)PlayerPrefs.GetInt("musicvolume") / 10;
        soundSource.volume = (float)PlayerPrefs.GetInt("soundvolume") / 10;
    }

    private void SaveAudioValue()
    {
        PlayerPrefs.SetInt("musicvolume", (int)musicSlider.value);
        PlayerPrefs.SetInt("soundvolume", (int)soundSlider.value);
    }
}