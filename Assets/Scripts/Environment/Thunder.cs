using UnityEngine;

using Sounds;
using Utilities;

using System.Collections;

namespace Environment
{
    public class Thunder : MonoBehaviour
    {
        [SerializeField] private Light _lightToEnable;
        [SerializeField] private float _intensityOnThundering = 0.2f;
        
        [Space] [SerializeField] private float _minDelayToThunder = 5f;
        [SerializeField] private float _maxDelayToThunder = 14f;

        [SerializeField] private float _timeOfThunderEnabled = 1f;

        [Space] [SerializeField] private bool _thunderOnStart;
        [SerializeField] private float _delayForThunderOnStart;

        [Space] [SerializeField] private bool _repeat = true;

        [SerializeField] private PlayRandomSound _thunderRandomSound;

        private IEnumerator Start()
        {
            if(!_thunderOnStart) yield break;
            
            yield return new WaitForSeconds(_delayForThunderOnStart);
            StartCoroutine(DoThunder());
        }

        private IEnumerator WaitForThunder()
        {
            var wait = GenerateRandomValue.GenerateRandomFloat(_minDelayToThunder, _maxDelayToThunder);
            yield return new WaitForSeconds(wait);

            StartCoroutine(DoThunder());
        }

        private IEnumerator DoThunder()
        {
            _lightToEnable.intensity = _intensityOnThundering;
            if (_thunderRandomSound != null) _thunderRandomSound._PlayRandomSound();
            
            yield return new WaitForSeconds(_timeOfThunderEnabled);
            _lightToEnable.intensity = 0;
            
            if(!_repeat) yield break;
            StartCoroutine(WaitForThunder());
        }
    }
}