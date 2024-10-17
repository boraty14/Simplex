using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Game.Scripts.Core.SoundSystem
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