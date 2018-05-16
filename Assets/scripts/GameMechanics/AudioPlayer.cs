using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    public AudioClip[] musicList; //0 = menu music, 1 = song01 2= song2 etc..
    public AudioClip[] sfxSound; //0 = mouseClick, 1 = buildClick
    private int musicIndex = 0;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            next();
            audioSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.PageUp)) next();
        if (Input.GetKeyDown(KeyCode.PageDown))previous();
    }

    private void next()
    {
        if (musicIndex != musicList.Length -1)
        {
            musicIndex++;
        }
        else
        {
            musicIndex = 0;
        }
        audioSource.clip = musicList[musicIndex];
        audioSource.Play();
    }
    private void previous()
    {if (musicIndex != 0)
        {
            musicIndex--;
        }
        else
        {
            musicIndex = musicList.Length - 1;
        }
        audioSource.clip = musicList[musicIndex];
        audioSource.Play();
    }

}
