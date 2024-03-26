using UnityEngine;
using UnityEngine.Events;

using DataModel;
using TMPro;

using System;

namespace Decisions
{
    public class MakeDecision : MonoBehaviour
    {
        [SerializeField] private GameObject _decisionButtonsParent;
        [SerializeField] private DecisionData[] _decisionsData;

        private GameSession _session;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
        }

        private void OnEnable()
        {
            ReBuildDecisionObjects();
        }

        private void ReBuildDecisionObjects()
        {
            foreach (var decisionData in _decisionsData)
            {
                decisionData.TextComponent.text = decisionData.DecisionText;
            }
        }

        public void Choose(int index)
        {
            _decisionsData[index].ChoseEvent?.Invoke();

            _session.MakeDecision(index);
            
            _decisionButtonsParent.SetActive(false);
            enabled = false;
        }

        [Serializable]
        public class DecisionData
        {
            public TextMeshProUGUI TextComponent;
            public string DecisionText;

            public UnityEvent ChoseEvent;
        }
    }
}