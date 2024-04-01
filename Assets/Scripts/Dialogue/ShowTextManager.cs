using System.Collections.Generic;
using UnityEngine;
using TMPro;

using System.Threading.Tasks;
using UnityEngine.Events;

namespace Dialogue
{
    public class ShowTextManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textComponent;
        
        [SerializeField] private float _showSpeedDelta;
        [SerializeField, Tooltip("In milliseconds")] private int _defaultWaitTime = 2000;

        [SerializeField] private List<string> _toShow = new List<string>();
        private bool _processingTask;

        private UnityEvent _onStopShowing;
        
        public async void _OnShowText(string dialogueText, UnityEvent onEnd)
        {
            _onStopShowing = onEnd;
            
            _toShow.Add(dialogueText);
            
            if(_processingTask) return;
            await ShowText();
        }
        
        private async Task ShowText()
        {
            _processingTask = true;
            _textComponent.text = _toShow[0];

            var newColor = _textComponent.color;
            while (_textComponent.color.a < 0.999f)
            {
                newColor.a = Mathf.Clamp01(newColor.a + _showSpeedDelta);
                _textComponent.color = newColor;
                
                await Task.Yield();
            }

            _toShow.RemoveAt(0);
            await HideText();
        }

        private async Task HideText()
        {
            await Task.Delay(_defaultWaitTime);
            
            var newColor = _textComponent.color;
            while (_textComponent.color.a > 0.001f)
            {
                newColor.a = Mathf.Clamp01(newColor.a - _showSpeedDelta);
                _textComponent.color = newColor;

                await Task.Yield();
            }

            if (_toShow.Count > 0)
            {
                await ShowText();
            }
            else
            {
                _processingTask = false;
                _onStopShowing?.Invoke();

                _onStopShowing?.RemoveAllListeners();
            }
        }
    }
}