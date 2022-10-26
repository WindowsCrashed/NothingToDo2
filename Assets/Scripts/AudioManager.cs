using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] List<Sound> sounds;

    void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.loop = sound.loop;
        }    
    }

    public void PlayClip(string name)
    {
        sounds.Find(s => s.name == name).source.Play();
    }

    public void StopClip(string name)
    {
        sounds.Find(s => s.name == name).source.Stop();
    }
}
