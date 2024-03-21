using System;
using UnityEngine;
using UnityEngine.Events;

namespace Events.Collider
{
    public class CollisionExit : MonoBehaviour
    {
        [SerializeField] private string _tag = "Player";
        [SerializeField] private CollisionExitEvent _event;

        private void OnCollisionExit(Collision other)
        {
            if(!other.gameObject.CompareTag(_tag)) return;
            _event?.Invoke(other.gameObject);
        }

        [Serializable]
        public class CollisionExitEvent : UnityEvent<GameObject>{}
    }
}