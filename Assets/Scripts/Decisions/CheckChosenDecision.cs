using DataModel;
using UnityEngine;
using UnityEngine.Events;

namespace Decisions
{
    public class CheckChosenDecision : MonoBehaviour
    {
        [SerializeField] private int _toCheckDecisionInOrder;
        [SerializeField] private UnityEvent[] _eventByDecisionIndex;
        
        private GameSession _session;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
        }

        public void _CheckDecision()
        {
            var decisionEvent = _session.GetDecision(_toCheckDecisionInOrder);
            _eventByDecisionIndex[decisionEvent]?.Invoke();
        }
    }
}