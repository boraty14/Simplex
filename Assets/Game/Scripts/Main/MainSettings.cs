using Game.Scripts.Sound;
using UnityEngine;

namespace Game.Scripts.Main
{
    [CreateAssetMenu(menuName = "Game/Settings/Main Settings", fileName = "MainSettings")]
    public class MainSettings : ScriptableObject
    {
        public SoundManagerSettings soundManagerSettings;
    }
}