using UnityEngine;
using System.Collections;

using Utilities;

namespace Environment
{
    public class FlickeringLight : MonoBehaviour
    {
        [SerializeField] private Light _flickeringLight;
        [SerializeField] private bool _flickering;

        [ContextMenu("Unit test")]
        private void Unit()
        {
            _Flicker(_flickeringLight, 0.3f, 1f, 0.08f);
        }

        public void _Flicker(Light lightToFlicker, float minIntensity, float maxIntensity, float delayBetweenFlickering)
        {
            _flickeringLight = lightToFlicker;
            _flickering = true;
            
            StartCoroutine(Flicker(minIntensity, maxIntensity, delayBetweenFlickering));
        }

        public void _DisableFlickering()
        {
            _flickering = false;
            _flickeringLight.intensity = 0;
        }

        private IEnumerator Flicker(float minIntensity, float maxIntensity, float delayBetweenFlickering)
        {
#if UNITY_EDITOR
            if (delayBetweenFlickering <= 0)
            {
                Debug.LogWarning($"Delay between flickering <= 0. {this}");
                _flickering = false;
            }
#endif
            while (_flickering)
            {
                _flickeringLight.intensity = GenerateRandomValue.GenerateRandomFloat(minIntensity, maxIntensity);

                yield return new WaitForSeconds(delayBetweenFlickering);
            }
        }
    }
}
