using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace UI
{
    public class HelpText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _helpTextComponent;
        [SerializeField, TextArea(0, 3)] private string _helpText;

        [Space] [SerializeField] private float _showDelta = 0.001f;

        [SerializeField] private bool _showOnce;
        public bool StillHasShow;

        public async void _ShowHelpText()
        {
            _helpTextComponent.text = _helpText;
            
            var newColor = _helpTextComponent.color;
            while (_helpTextComponent.color.a < 0.97f && StillHasShow)
            {
                newColor.a = Mathf.Clamp01(newColor.a + _showDelta);
                _helpTextComponent.color = newColor;
                
                await Task.Yield();
            }
            HideHelpText();
        }

        private async void HideHelpText()
        {
            var newColor = _helpTextComponent.color;
            while (_helpTextComponent.color.a > 0.01f)
            {
                newColor.a = Mathf.Clamp01(newColor.a - _showDelta);
                _helpTextComponent.color = newColor;

                await Task.Yield();
            }

            newColor.a = 0;
            _helpTextComponent.color = newColor;

            if (!StillHasShow || _showOnce) return;
            _ShowHelpText();
        }

        public void _SetShowOnce(bool showOnce)
        {
            _showOnce = showOnce;
        }

        public void _SetHelpText(string text)
        {
            _helpTextComponent.text = _helpText;
        }

        public void _StopShowing()
        {
            StillHasShow = false;
        }
    }
}