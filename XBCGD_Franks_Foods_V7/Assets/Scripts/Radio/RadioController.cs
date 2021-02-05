using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController : MonoBehaviour
{
    public AudioClip[] Songs;
    public AudioSource audioSource;
    public ParticleSystem particles;

    [SerializeField]
    bool canPlay;
    [SerializeField]
    int songIndex;

    private void Start()
    {
        songIndex = 0;
        audioSource = GetComponent<AudioSource>();

        if (Songs.Length == 0 || audioSource == null)
        {
            canPlay = false;
        }
        else
        {
            canPlay = true;
            audioSource.clip = Songs[songIndex];
            audioSource.loop = true;
            audioSource.Play();
            particles.Play();
        }
    }

    private void OnMouseDown()
    {
        if (canPlay)
        {
            if (songIndex == Songs.Length - 1)
            {
                songIndex = 0;
            }
            else
            {
                songIndex++;
            }

            audioSource.clip = Songs[songIndex];
            audioSource.Play();
        }
    }
}
