using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource music, sound;

    public void MusicManager(bool value)
    {
        if (value)
        {
            music.Play();
            return;
        }
        music.Stop();
    }
    public void SoundManager(bool value)
    {
        if (value)
        {
            sound.Play();
            return;
        }
        sound.Stop();
    }
}
