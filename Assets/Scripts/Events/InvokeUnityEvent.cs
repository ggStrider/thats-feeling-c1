using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class InvokeUnityEvent : MonoBehaviour
    {
        [SerializeField] private UnityEvent _action;

        [Space] [SerializeField] private bool _canInvoke;
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

            _action?.Invoke();
            if(_canInvokeOnce) 
            { 
                _canInvoke = false; 
            }
        }

        public void ChangeBoolCanInvoke(bool canInvoke)
        {
            _canInvoke = canInvoke;
        }
    }
}