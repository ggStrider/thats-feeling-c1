using System;
using System.Collections.Generic;
using System.Linq;
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

        [Space] [SerializeField] private bool _excludeRepeating;
        private List<AudioClip> _availableClips;
        
        [Space] [SerializeField] private UnityEvent _onComplete;

        private void Awake()
        {
            _availableClips = _clips.ToList();
                
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
            if (_excludeRepeating)
            {
                _source.clip = _availableClips[GenerateRandomValue.GenerateRandomInt(0, _availableClips.Count)];
                _source.Play();
                WaitAndInvoke(clipNumber);
                
                return;
            }
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