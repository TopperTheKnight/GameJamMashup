using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClips : MonoBehaviour {
    [SerializeField]
    AudioClip[] audioClips;
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayRussian()
    {
        audio.Stop();
        audio.clip = audioClips[0];
        audio.Play();
    }
    public void PlayMexico()
    {
        audio.Stop();
        audio.clip = audioClips[1];
        audio.Play();
    }
    public void PlayUS()
    {
        audio.Stop();
        audio.clip = audioClips[2];
        audio.Play();
    }
    public void PlayKorea()
    {
        audio.Stop();
        audio.clip = audioClips[3];
        audio.Play();
    }
    public void PlayStandard()
    {
        audio.Stop();
        audio.clip = audioClips[4];
        audio.Play();
    }

}
