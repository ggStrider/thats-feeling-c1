using System;
using UnityEngine;
using UnityEngine.Events;

namespace Events.Collider
{
    public class CollisionEnter : MonoBehaviour
    {
        [SerializeField] private string _tag = "Player";
        [SerializeField] private CollisionEnterEvent _event;

        private void OnCollisionEnter(Collision other)
        {
            if(!other.gameObject.CompareTag(_tag)) return;
            _event?.Invoke(other.gameObject);
        }

        [Serializable]
        public class CollisionEnterEvent : UnityEvent<GameObject>{}
    }
}