using UnityEngine;
using UnityEngine.Events;

using System;
using System.Collections;

namespace Sounds
{
    public class PlaySoundsSequentially : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private Sounds[] _soundsData;

        public void _OnPlaySoundsSequentially()
        {
            StartCoroutine(PlayEachSoundSequentially());
        }
        
        private IEnumerator PlayEachSoundSequentially()
        {
            foreach (var soundsData in _soundsData)
            {
                _source.clip = soundsData.Sound;
                yield return new WaitForSeconds(soundsData.Sound.length + soundsData.AdditionalDelay);
                
                soundsData.OnComplete?.Invoke();
            }
        }

        [Serializable]
        public struct Sounds
        {
            public AudioClip Sound;
            public UnityEvent OnComplete;

            public float AdditionalDelay;
        }
    }
}