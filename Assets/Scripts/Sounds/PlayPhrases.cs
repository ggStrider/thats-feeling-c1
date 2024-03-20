using UnityEngine;
using UnityEngine.Events;

using System;
using System.Collections;

namespace Sounds
{
    public class PlayPhrases : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private Phrases[] _phrasesData;

        public void _OnPlayPhrasesSequentially()
        {
            StartCoroutine(PlayPhrasesSequentially());
        }
        
        private IEnumerator PlayPhrasesSequentially()
        {
            foreach (var phraseData in _phrasesData)
            {
                _source.clip = phraseData.Phrase;
                yield return new WaitForSeconds(phraseData.Phrase.length + phraseData.AdditionalDelay);
                
                phraseData.OnComplete?.Invoke();
            }
        }

        [Serializable]
        public struct Phrases
        {
            public AudioClip Phrase;
            public UnityEvent OnComplete;

            public float AdditionalDelay;
        }
    }
}