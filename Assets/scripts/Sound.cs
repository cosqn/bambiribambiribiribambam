using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class representing each sound element
[System.Serializable]
public class Sound
{
    public string name;             // Name of the sound
    public AudioClip clip;          // Sound file
    [Range(0f, 1f)]                 // Volume range
    public float volume;            // Sound volume
    [Range(.1f, 3f)]                // Pitch range
    public float pitch;             // Sound pitch
    public AudioSource source;      // Audio source where the sound will be played
    public bool loop;               // Whether the sound should loop
}

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;  // Array containing the sounds

    void Start()
    {
        // Set up the sounds at the start
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();  // Create an AudioSource component for each sound
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    // You can add methods here to play, stop, or manipulate sounds
}