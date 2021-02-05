using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }  

    /////////////////////////////////////////////////////////////////
    public void DecreaseVolume(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume -= .2f;
    }

    public void IncreaseVolume(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume += .2f;
    }

    public void Mute(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = 0.0f;

    }

    public void Unmute(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = 6.0f;

    }
}
