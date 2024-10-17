using UnityEngine;

namespace Game.Scripts.Core.Settings
{
    [CreateAssetMenu(menuName = "Game/Settings/Game Settings", fileName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        public SoundManagerSettings soundManagerSettings;
    }
}