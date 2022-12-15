using UnityEngine;

public class GameSound : MonoBehaviour
{
    [SerializeField] private AudioSource[] sounds, musics;
    private void Start()
    {
        SetSoundVolume();
        SetMusicVolume();
    }

    private void SetSoundVolume()
    {
        for (int i = 0; i < sounds.Length; i++)
            sounds[i].volume = (float)PlayerPrefs.GetInt("soundvolume") / 10;
    }

    private void SetMusicVolume()
    {
        for (int i = 0; i < musics.Length; i++)
            musics[i].volume = (float)PlayerPrefs.GetInt("musicvolume") / 10;
    }
}