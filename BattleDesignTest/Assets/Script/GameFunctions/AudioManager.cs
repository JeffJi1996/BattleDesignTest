using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            if (s.outPutGroup == null)
            {
                s.source.outputAudioMixerGroup = sounds[0].outPutGroup;
            }
            else
            {
                //Debug.Log(s.name);
                s.source.outputAudioMixerGroup = s.outPutGroup;
            }
            //s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }

    void Start()
    {
        //Play("Player_Death");
        Play("Amb");
    }

    // Update is called once per frame
    //take in a string with the name of our sound
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "not found!");
            return;
        }
        Debug.Log(s.name);
        AudioSource source = s.source;
        s.source.clip = s.clips[Random.Range(0,s.clips.Length)];
        s.source.Play();
        //Debug.Log("sounds great!");

    }
}
