using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Sounds
{
    public class PlayOneSound : MonoBehaviour
    {
        [Tooltip("Leave it alone = get source on this object")]
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip _sound;
        
        [Space] [SerializeField] private bool _fadeIn;
        [SerializeField, Range(0, 1)] private float _fadeInStartVolume;
        [SerializeField, Range(0, 1)] private float _fadeInEndVolume;
        [SerializeField] private float _addDelta;

        [SerializeField] private float _delayToFadeIn;

        [Space] [SerializeField] private float _fadeOutDelta;
        
        [Space, SerializeField] private UnityEvent _onComplete;

        private void Awake()
        {
            if(_source != null) return;
            _source = GetComponent<AudioSource>();
        }
        
        public void _OnPlaySound()
        {
            _source.clip = _sound;
            _source.Play();
            
            Invoke(nameof(PlaySound), _sound.length);
            
            if(!_fadeIn) return;
            StartCoroutine(FadeIn());
        }
        
        private void PlaySound()
        {
            _onComplete?.Invoke();
        }

        public void _OnFadeOut()
        {
            StartCoroutine(FadeOut());
        }

        private IEnumerator FadeOut()
        {
            var currentVolume = _source.volume;
            while (currentVolume > 0)
            {
                currentVolume -= _fadeOutDelta;
                _source.volume = Mathf.Clamp01(currentVolume);
                
                yield return null;
            }
        }

        private IEnumerator FadeIn()
        {
            _source.volume = _fadeInStartVolume;
            yield return new WaitForSeconds(_delayToFadeIn);

            var currentVolume = _fadeInStartVolume;
            while (currentVolume < _fadeInEndVolume)
            {
                currentVolume += _addDelta;
                _source.volume = Mathf.Clamp(currentVolume, 0, _fadeInEndVolume);
                
                yield return null;
            }
        }
    }
}