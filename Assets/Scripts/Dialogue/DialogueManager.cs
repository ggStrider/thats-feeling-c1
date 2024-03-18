using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public async void _OnShowText()
        {
            await ShowText();
        }
        
        private async Task ShowText()
        {
            
        } 
    }
}