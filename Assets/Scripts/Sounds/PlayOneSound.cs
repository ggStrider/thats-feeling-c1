using UnityEngine;
using UnityEngine.Events;

using System.Collections;

namespace Sounds
{
    public class PlayOneSound : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip _sound;

        [Space, SerializeField] private UnityEvent _onComplete;

        public void _OnPlaySound()
        {
            StartCoroutine(PlaySound());
        }
        
        private IEnumerator PlaySound()
        {
            _source.clip = _sound;

            yield return new WaitForSeconds(_sound.length);
            _onComplete?.Invoke();
        }
    }
}