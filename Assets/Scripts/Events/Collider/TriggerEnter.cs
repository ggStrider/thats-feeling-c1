using UnityEngine;
using UnityEngine.Events;

using System;

namespace Events.Collider
{
    public class TriggerEnter : MonoBehaviour
    {
        [SerializeField] private string _tag = "Player";
        [SerializeField] private TriggerEnterEvent _event;

        private void OnTriggerEnter(UnityEngine.Collider other)
        {
            if(!other.CompareTag(_tag)) return;
            _event?.Invoke(other.gameObject);
        }

        [Serializable]
        public class TriggerEnterEvent : UnityEvent<GameObject>{}
    }
}