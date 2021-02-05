using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerMainMenu : MonoBehaviour
{
    public AudioManager audioManagerObj;

    private void Start()
    {
        audioManagerObj.Play("Theme");
    }

    public void DecVol()
    {
        for (int i = 0; i < audioManagerObj.sounds.Length; i++)
        {
            audioManagerObj.DecreaseVolume(audioManagerObj.sounds[i].name);

        }
    }

    public void IncVol()
    {
        for (int i = 0; i < audioManagerObj.sounds.Length; i++)
        {
            audioManagerObj.IncreaseVolume(audioManagerObj.sounds[i].name);

        }
    }

    public void Mute()
    {
        for (int i = 0; i < audioManagerObj.sounds.Length; i++)
        {

            if (audioManagerObj.sounds[i].volume == 0.0f)
            {
                audioManagerObj.Unmute(audioManagerObj.sounds[i].name);
            }

            audioManagerObj.Mute(audioManagerObj.sounds[i].name);

        }
    }
}
