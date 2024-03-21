using System;
using UnityEngine;
using UnityEngine.Events;

namespace Events.Collider
{
    public class TriggerExit : MonoBehaviour
    {
        [SerializeField] private string _tag = "Player";
        [SerializeField] private TriggerExitEvent _event;

        private void OnTriggerExit(UnityEngine.Collider other)
        {
            if(!other.CompareTag(_tag)) return;
            _event?.Invoke(other.gameObject);
        }

        [Serializable]
        public class TriggerExitEvent : UnityEvent<GameObject>{}
    }
}