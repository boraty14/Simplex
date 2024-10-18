using System;
using Cysharp.Threading.Tasks;
using Game.Scripts.Components;
using Game.Scripts.Sound;
using UnityEngine;
using VContainer;

namespace Game.Scripts.GameTask
{
    public class StartGameTask : GameTaskBase
    {
        private readonly SoundService _soundService;
        private readonly SoundSettings _soundSettings;
        private readonly RootLoadingScreen _rootLoadingScreen;

        [Inject]
        public StartGameTask(SoundService soundService, SoundSettings soundSettings, RootLoadingScreen rootLoadingScreen)
        {
            _soundService = soundService;
            _soundSettings = soundSettings;
            _rootLoadingScreen = rootLoadingScreen;
        }
        
        public override async UniTask Run()
        {
            _rootLoadingScreen.Toggle(true);
            _soundService.CreateSound()
                .WithSoundData(_soundSettings.gameStartSoundData)
                .WithRandomPitch()
                .WithPosition(Vector3.zero)
                .Play();
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            _rootLoadingScreen.Toggle(false);
        }
    }
}