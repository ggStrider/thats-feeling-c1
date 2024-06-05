using UnityEngine;

using Environment;
using Sounds;

namespace InteractFeatures.Interact
{
    public class ToggleLight : MonoBehaviour, IInteract
    {
        [SerializeField] private Light _lightToToggle;
        [SerializeField] private float _intensityOnEnabled;
        [SerializeField] private bool _enabledLight;

        [Space] [SerializeField] private GameObject _switcherOnEnabled;
        [SerializeField] private GameObject _switcherOnDisabled;

        [Space] [SerializeField] private PlayRandomSound _turnedOnSound;
        [SerializeField] private PlayRandomSound _turnedOffSound;
        
        [Space] [SerializeField] private bool _canUse = true; 
        
        [Space] [Header("Change value here only if this light should flicker")]
        [SerializeField] private bool _shouldFlickering;
        
        [SerializeField] private float _minIntensityForFlickering;
        [SerializeField] private float _maxIntensityForFlickering;
        [SerializeField] private float _delayBetweenFlickering;
        
        private FlickeringLight _flickeringLightComponent;

        private void Start()
        {
            if (_shouldFlickering)
            {
                var flickeringComponent = GetComponent<FlickeringLight>();
                _flickeringLightComponent = flickeringComponent != null ? flickeringComponent : gameObject.AddComponent<FlickeringLight>();
            }
            
            if (_lightToToggle == null)
            {
                Debug.Log("Light to toggle is null");
                return;
            }
            
            _enabledLight = _lightToToggle.intensity > 0;
            Toggle();
        }

        public void Interact()
        {
            if (!_canUse || _lightToToggle == null)
            {
                Debug.Log($"Can use = {_canUse}; Light to toggle = {_lightToToggle}");
                return;
            }
            
            _enabledLight = !_enabledLight;
            (_enabledLight ? _turnedOnSound : _turnedOffSound)?._PlayRandomSound();
            Toggle();
        }

        private void Toggle()
        {
            SwitchToggleObject();

            if (_shouldFlickering)
            {
                if (_enabledLight)
                {
                    _flickeringLightComponent._Flicker(_lightToToggle, _minIntensityForFlickering, _maxIntensityForFlickering, _delayBetweenFlickering);
                }
                else
                {
                    _flickeringLightComponent._DisableFlickering();
                }
            }
            
            else
            {
                _lightToToggle.intensity = _enabledLight ? _intensityOnEnabled : 0;
            }
        }

        private void SwitchToggleObject()
        {
            if (_enabledLight)
            {
                _switcherOnEnabled.SetActive(true);
                _switcherOnDisabled.SetActive(false);
            }
            else
            {
                _switcherOnEnabled.SetActive(false);
                _switcherOnDisabled.SetActive(true);
            }
        }
    }
}
