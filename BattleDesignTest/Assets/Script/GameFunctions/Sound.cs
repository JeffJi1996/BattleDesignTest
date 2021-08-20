using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    // have a list of sounds where we can easily add or remove sounds as we use 
    // and we hope we have different properties it has an audio clip, 
    // We use this to control what data is stored in each sound  so we need to creat a custom class  to do that we go inside of unity we go

    public string name;
    public AudioClip[] clips;
    [Range(0f, 1f)]
    public float volume;

    public AudioMixerGroup outPutGroup;




    [Range(.1f, 3f)]
    public float pitch;

    //when we want to play the sound we can tell the play method on the audio source
    //we creat public audio source and let's call it source of course

    [HideInInspector]
    public AudioSource source;

    public bool loop;


}
