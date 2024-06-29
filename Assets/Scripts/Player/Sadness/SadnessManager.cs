using UnityEngine;

using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

using System.Collections;

namespace Player.Sadness
{
    public class SadnessManager : MonoBehaviour
    {
        [SerializeField] private float _sadnessLevel;
        [SerializeField] private ColorAdjustments _colorAdjustments;

        private void Start()
        {
            var postProcessingVolume = FindObjectOfType<Volume>();
            postProcessingVolume.profile.TryGet(out _colorAdjustments);
        }

        public void ChangeSadness(float sadnessDelta)
        {
            _sadnessLevel = Mathf.Clamp(_sadnessLevel + sadnessDelta, -100, 100);
            _colorAdjustments.saturation.value = _sadnessLevel;
        }

        public IEnumerator ChangeSadnessSmoothly(float changeDelta, float duration, AnimationCurve changeValueCurve)
        {
            var elapsedTime = .0f;
            var initializeSadness = _sadnessLevel;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                
                var t = changeValueCurve.Evaluate(elapsedTime / duration);
                var interpolateValue = Mathf.Lerp(initializeSadness, initializeSadness + changeDelta, t);
                
                _sadnessLevel = Mathf.Clamp(interpolateValue, -100, 100);
                Debug.Log($"Level: {_sadnessLevel}, elapsed: {elapsedTime}");

                _colorAdjustments.saturation.value = _sadnessLevel;

                yield return null;
            }
        }
    }
}
