using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class EventOnEnable : MonoBehaviour
    {
        [SerializeField] private UnityEvent _unityEvent;

        public void OnEnable()
        {
            _unityEvent?.Invoke();
        }
    }
}
