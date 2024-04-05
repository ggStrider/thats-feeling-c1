using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class InvokeUnityEvent : MonoBehaviour
    {
        [field: SerializeField] public UnityEvent unityEvent;

        [Space] [SerializeField] private bool _canInvoke = true;
        [SerializeField] private bool _canInvokeOnce;

        [Space] [SerializeField] private bool _invokeOnStart;

        private void Start()
        {
            if(_invokeOnStart)
                _InvokeEvent();
        }

        public void _InvokeEvent()
        {
            if (!_canInvoke) return;

            unityEvent?.Invoke();
            if(_canInvokeOnce) 
            {
                _canInvoke = false; 
            }
        }

        public void _ChangeBoolCanInvoke(bool canInvoke)
        {
            _canInvoke = canInvoke;
        }
    }
}