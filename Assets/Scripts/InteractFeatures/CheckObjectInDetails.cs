using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InteractFeatures
{
    public class CheckObjectInDetails : MonoBehaviour
    {
        [SerializeField, Tooltip("Leave it null = this")] 
        private GameObject _objectToCheck;

        [SerializeField] private Transform _placeForInstantiate;

        [SerializeField] private bool _isChecking;
        [SerializeField] private Vector2 _lim;
        [SerializeField] private Vector2 _max;

        private GameObject _instantiatedCheckObject;
        [SerializeField] private PlayerSetSettings _playerSetSettings;

        private void Start()
        {
            _playerSetSettings = FindObjectOfType<PlayerSetSettings>();
            if (_objectToCheck != null) return;
            
            _objectToCheck = gameObject;
        }

        [ContextMenu("check")]
        public void _CheckObjectInDetails()
        {
            _instantiatedCheckObject = Instantiate(_objectToCheck, _placeForInstantiate.position, Quaternion.identity);
            _isChecking = true;
            
            _playerSetSettings._CanCameraRotate(false);
        }

        private void Update()
        {
            if(!_isChecking) return;
            // Дописать як треба буде
        }
    }
}