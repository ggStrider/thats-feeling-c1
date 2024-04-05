using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using System.Threading.Tasks;

namespace UI
{
    public class Fader : MonoBehaviour
    {
        [SerializeField] private Image _blackScreen;
        [SerializeField] private float _fadeSpeed;
        [SerializeField] private float _unFadeSpeed;

        [Space] [SerializeField] private bool _unFadeOnStart;

        [SerializeField] private UnityEvent _faded;
        [SerializeField] private UnityEvent _unFaded;

        private async void Start()
        {
            if (_unFadeOnStart) await UnFade(0);
        }

        public async void _OnFade(float fadeSpeed)
        {
            await Fade(fadeSpeed);
        }
        
        public async void _OnUnFade(float unFadeSpeed)
        {
            await UnFade(unFadeSpeed);
        }
        
        public async Task UnFade(float unFadeSpeed)
        {
            var newColor = _blackScreen.color;

            var speed = unFadeSpeed > 0 ? unFadeSpeed : _unFadeSpeed;
            while (_blackScreen.color.a > 0)
            {
                if (_blackScreen == null) return;
                
                newColor.a = Mathf.Clamp01(newColor.a - speed);
                _blackScreen.color = newColor;

                await Task.Yield();
            }
            
            _unFaded?.Invoke();
        }
        
        public async Task Fade(float fadeSpeed)
        {
            var newColor = _blackScreen.color;
            
            var speed = fadeSpeed > 0 ? fadeSpeed : _fadeSpeed;
            while (_blackScreen.color.a < 1)
            {
                if (_blackScreen == null) return;

                newColor.a = Mathf.Clamp01(newColor.a + speed);
                _blackScreen.color = newColor;

                await Task.Yield();
            }
            
            _faded?.Invoke();
        }
    }
}