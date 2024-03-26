using DataModel;
using UnityEngine;
using UnityEngine.Events;

namespace InteractFeatures
{
    public class TakeItem : MonoBehaviour
    {
        [SerializeField] private Transform _place;

        [Space, Tooltip("leaving it null = this game object")]
        [SerializeField] private GameObject _objectToTake;
        [SerializeField] private bool _takeToHand;
        
        [Space]
        [SerializeField] private Vector3 _size;
        [SerializeField] private Vector3 _putOffset;
        [SerializeField] private Vector3 _rotationOffset;

        public bool _canTake = true ;
        
        [SerializeField] private UnityEvent _onTake;

        private GameSession _session;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
            
            if(_objectToTake != null) return;
            _objectToTake = gameObject;
        }

        [ContextMenu("take")]
        public void _Take()
        {
            if(!_canTake) return;
            _session.AddItem(_objectToTake, _takeToHand);

            if (!_takeToHand)
            {
                Destroy(gameObject);
                return;
            }
            
            _objectToTake.transform.localScale = _size;
            _objectToTake.transform.parent = _place;
            
            _objectToTake.transform.SetLocalPositionAndRotation(_putOffset, Quaternion.Euler(_rotationOffset));
            _onTake?.Invoke();
            
            enabled = false;
        }
    }
}
