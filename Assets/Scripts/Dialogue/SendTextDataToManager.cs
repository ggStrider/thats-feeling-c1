using UnityEngine;
using UnityEngine.Events;

namespace Dialogue
{
    public class SendTextDataToManager : MonoBehaviour
    {
        [SerializeField, TextArea(0, 5)] private string[] _texts;
        [SerializeField] private UnityEvent _onTextShowed;
        
        private ShowTextManager _showTextManager;

        private void Awake()
        {
            _showTextManager = FindObjectOfType<ShowTextManager>();
        }

        public void _OnSendData()
        {
            foreach (var text in _texts)
            {
                _showTextManager._OnShowText(text, _onTextShowed);
            }
        }
    }
}