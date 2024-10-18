using System;
using UnityEngine;
using UnityEngine.Audio;


// how to inject?
namespace Game.Scripts.Sound
{
    [Serializable]
    public class SoundData
    {
        public AudioClip clip;
        public AudioMixerGroup mixerGroup;
        [Range(0f,1f)] public float volume;
        public bool loop;
        public bool playOnAwake;
    }
}