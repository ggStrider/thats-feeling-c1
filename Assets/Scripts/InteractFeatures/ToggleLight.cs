using Sounds;
using UnityEngine;

namespace InteractFeatures
{
    public class ToggleLight : MonoBehaviour
    {
        [SerializeField] private Light _lightToToggle;
        [SerializeField] private float _intensityOnEnabled;
        [SerializeField] private bool _enabled;

        [Space] [SerializeField] private GameObject _switcherOnEnabled;
        [SerializeField] private GameObject _switcherOnDisabled;

        [Space] [SerializeField] private PlayRandomSound _turnedOnSound;
        [SerializeField] private PlayRandomSound _turnedOffSound;
        
        [Space] [SerializeField] private bool _canUse; 

        private void Awake()
        {
            if(_lightToToggle == null) return;
            
            _enabled = _lightToToggle.intensity > 0;
            ToggleObjectAndPlaySound();
        }

        public void _Toggle()
        {
            if(!_canUse || _lightToToggle == null) return;
            
            _enabled = !_enabled;
            _lightToToggle.intensity = _enabled ? _intensityOnEnabled : 0;

            (enabled ? _turnedOnSound : _turnedOffSound)?._PlayRandomSound();
            ToggleObjectAndPlaySound();
        }

        private void ToggleObjectAndPlaySound()
        {
            if (_enabled)
            {
                _switcherOnEnabled.SetActive(true);
                _switcherOnDisabled.SetActive(false);
                
            }
            else
            {
                _switcherOnEnabled.SetActive(false);
                _switcherOnDisabled.SetActive(true);

                _turnedOffSound._PlayRandomSound();
            }
        }
    }   
}
