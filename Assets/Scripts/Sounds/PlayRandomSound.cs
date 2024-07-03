using UnityEngine;
using UnityEngine.Events;

using Utilities;

using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

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
        [SerializeField] private List<AudioClip> _availableClips;
        
        [Space] [SerializeField] private UnityEvent _onComplete;

        private void Awake()
        {
            _availableClips = _clips.ToList();
            
            if(_source != null) return;
            _source = GetComponent<AudioSource>();
        }

        [ContextMenu("Play")]
        public void _PlayRandomSound()
        {
            if (_randomPitch)
            {
                var newPitch = GenerateRandomValue.GenerateRandomFloat(_minPitch, _maxPitch);
                _source.pitch = newPitch;
            }
            
            if (_excludeRepeating)
            {
                PlaySoundWithExcluding();
            }
            else
            {
                PlayAnySound();
            }
            
            var clipNumber = GenerateRandomValue.GenerateRandomInt(0, _clips.Length);
            _source.clip = _clips[clipNumber];
            
            _source.Play();

            CompleteSoundInvoking(clipNumber);
        }

        private void PlaySoundWithExcluding()
        {
            if (_availableClips.Count == 0)
            {
                Debug.Log("Available clips count = 0");
                return;
            }
            var clipNumber = GenerateRandomValue.GenerateRandomInt(0, _availableClips.Count);
            
            _source.clip = _clips[clipNumber];
            _availableClips.Remove(_availableClips[clipNumber]);

            _source.Play();
            CompleteSoundInvoking(clipNumber);
        }

        private void PlayAnySound()
        {
            var clipNumber = GenerateRandomValue.GenerateRandomInt(0, _clips.Length);
            
            _source.clip = _clips[clipNumber];

            _source.Play();
            CompleteSoundInvoking(clipNumber);
        }

        private async void CompleteSoundInvoking(int clipNumber)
        {
            await Task.Delay((int)_clips[clipNumber].length * 1000 + 500);
            _onComplete?.Invoke();
        }
    }
}