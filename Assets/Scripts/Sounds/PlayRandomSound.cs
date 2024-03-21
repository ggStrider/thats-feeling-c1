using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using Utilities;

namespace Sounds
{
    public class PlayRandomSound : MonoBehaviour
    {
        [Tooltip("Leave it alone = source on this object")]
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip[] _clips;

        [SerializeField] private bool _randomPitch;
        [SerializeField, Range(-3, 3)] private float _minPitch; 
        [SerializeField, Range(-3, 3)] private float _maxPitch; 
        
        [Space] [SerializeField] private UnityEvent _onComplete;

        private void Awake()
        {
            if(_source != null) return;
            _source = GetComponent<AudioSource>();
        }

        public void _PlayRandomSound()
        {
            if (_randomPitch)
            {
                var newPitch = GenerateRandomValue.GenerateRandomFloat(_minPitch, _maxPitch);
                _source.pitch = newPitch;
            }
            
            var clipNumber = GenerateRandomValue.GenerateRandomInt(0, _clips.Length);
            _source.clip = _clips[clipNumber];
            _source.Play();

            WaitAndInvoke(clipNumber);
        }

        private async void WaitAndInvoke(int clipNumber)
        {
            await Task.Delay((int)_clips[clipNumber].length * 1000 + 500);
            _onComplete?.Invoke();
        }
    }
}