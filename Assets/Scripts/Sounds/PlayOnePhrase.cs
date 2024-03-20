using UnityEngine;
using UnityEngine.Events;

using System.Collections;

namespace Sounds
{
    public class PlayOnePhrase : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip _phrase;

        [Space, SerializeField] private UnityEvent _onComplete;

        public void _OnPlayPhrase()
        {
            StartCoroutine(PlayPhrase());
        }
        
        private IEnumerator PlayPhrase()
        {
            _source.clip = _phrase;

            yield return new WaitForSeconds(_phrase.length);
            _onComplete?.Invoke();
        }
    }
}