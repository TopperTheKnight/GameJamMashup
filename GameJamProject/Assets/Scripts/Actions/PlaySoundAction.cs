using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlaySoundAction : Action
{
    public AudioClip soundToPlay;

    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public override bool ExecuteAction(GameObject dataObject)
    {
        if (soundToPlay != null)
        {

            source.PlayOneShot(soundToPlay);

            return true;
        }
        else
        {
            return false;
        }
    }
}