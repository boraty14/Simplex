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
        public bool loop;
        public bool playOnAwake;
    }
}