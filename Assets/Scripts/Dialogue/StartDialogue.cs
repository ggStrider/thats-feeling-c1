using System;
using UnityEngine;

namespace Dialogue
{
    public class StartDialogue : MonoBehaviour
    {
        [SerializeField] private string _text;
        private DialogueManager _dialogueManager;

        private void Awake()
        {
            _dialogueManager = FindObjectOfType<DialogueManager>();
        }

        [ContextMenu("unit 1")]
        public void _OnStartDialogue()
        {
            _dialogueManager._OnShowText(_text);
        }

        [ContextMenu("unit 2")]
        public void unit2()
        {
            _dialogueManager._OnShowText("дарова");
            _dialogueManager._OnShowText("шо ти");
            _dialogueManager._OnShowText("легенда");
        }
    }
}