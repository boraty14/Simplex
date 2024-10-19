using UnityEngine;
using VContainer.Unity;

namespace Game.Scripts.Root
{
    public class RootRunner : IInitializable
    {
        public void Initialize()
        {
            Application.targetFrameRate = 60;
        }
    }
}