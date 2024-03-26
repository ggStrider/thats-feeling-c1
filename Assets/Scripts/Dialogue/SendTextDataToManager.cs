using UnityEngine;

namespace Dialogue
{
    public class SendTextDataToManager : MonoBehaviour
    {
        [SerializeField] private string _text;
        private ShowTextManager _showTextManager;

        private void Awake()
        {
            _showTextManager = FindObjectOfType<ShowTextManager>();
        }

        [ContextMenu("unit 1")]
        public void _OnSendData()
        {
            _showTextManager._OnShowText(_text);
        }

        [ContextMenu("unit 2")]
        public void unit2()
        {
            _showTextManager._OnShowText("дарова");
            _showTextManager._OnShowText("шо ти");
            _showTextManager._OnShowText("легенда");
        }
    }
}