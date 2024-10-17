using System.Collections;
using UnityEngine;
using VContainer;

namespace Game.Scripts.Core.SoundSystem
{
    public class SoundEmitter : MonoBehaviour
    {
        [Inject] private SoundService _soundService;
        private AudioSource _audioSource;
        private Coroutine _playSoundCoroutine;

        private void Awake()
        {
            if (!TryGetComponent<AudioSource>(out _audioSource))
            {
                _audioSource = gameObject.AddComponent<AudioSource>();
            }
        }

        public void Init(SoundData soundData)
        {
            _audioSource.clip = soundData.clip;
            _audioSource.outputAudioMixerGroup = soundData.mixerGroup;
            _audioSource.loop = soundData.loop;
            _audioSource.playOnAwake = soundData.playOnAwake;
        }

        public void Play()
        {
            if (_playSoundCoroutine != null)
            {
                StopCoroutine(_playSoundCoroutine);
            }

            _audioSource.Play();
            _playSoundCoroutine = StartCoroutine(WaitForSoundToEndRoutine());
        }

        public void Stop()
        {
            if (_playSoundCoroutine != null)
            {
                StopCoroutine(_playSoundCoroutine);
                _playSoundCoroutine = null;
            }

            _audioSource.Stop();
            _soundService.ReturnToPool(this);
        }

        private IEnumerator WaitForSoundToEndRoutine()
        {
            yield return new WaitWhile(() => _audioSource.isPlaying);
            _soundService.ReturnToPool(this);
        }
    }
}