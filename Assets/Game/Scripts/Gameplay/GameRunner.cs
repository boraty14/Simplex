using UnityEngine;
using VContainer;

namespace Game.Scripts.Gameplay
{
    public class GameRunner : MonoBehaviour
    {
        [Inject] private GameStateData _gameStateData;
        
        private void Awake()
        {
            Debug.Log(_gameStateData.Id);
        }
    }
}