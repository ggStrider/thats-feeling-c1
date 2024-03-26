using UnityEngine;
using Events;

namespace Player
{
    [RequireComponent(typeof(PlayerSetSettings))]
    [RequireComponent(typeof(CheckObjectsInRay))]
    [RequireComponent(typeof(PlayerInputReader))]
    public class PlayerSystem : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rayCheckDistance;

        [field:SerializeField] public Camera VisionCamera { get; private set; }
        [SerializeField] private CheckObjectsInRay _checkInRay;
        [SerializeField] private CheckShoppingList _checkShoppingList;

        private PlayerSetSettings _playerSetSettings;
        private Rigidbody _rigidbody;

        private Vector2 _direction;
        
        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }
        
        public void Interact()
        {
            if (!_playerSetSettings.CanInteract) return;

            var playerCamera = VisionCamera.transform;
            var result = _checkInRay.Check(playerCamera.position,
                playerCamera.forward, _rayCheckDistance);

            if (result == null) return;
            var objectInvokeComponent = result.GetComponent<InvokeUnityEvent>();

            if (objectInvokeComponent == null) return;
            objectInvokeComponent._InvokeEvent();
        }

        public void GetUp()
        {
            if (_playerSetSettings.currentSitComponent == null) return;
            _playerSetSettings.currentSitComponent.GetUp();
        }

        public void CheckShoppingList()
        {
            _checkShoppingList.ToggleAnimation();
        }

        private void FixedUpdate()
        {
            var cameraForward = VisionCamera.transform.forward;
            cameraForward.y = 0;
            cameraForward.Normalize();

            var movementDirection = cameraForward * _direction.y + VisionCamera.transform.right * _direction.x;
            movementDirection.Normalize();

            var velocity = movementDirection * _speed;
            
            _rigidbody.velocity = new Vector3(velocity.x, _rigidbody.velocity.y, velocity.z);

#if UNITY_EDITOR
            Debug.DrawRay(VisionCamera.transform.position, VisionCamera.transform.forward * _rayCheckDistance,
                Color.green);
#endif
        }
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _playerSetSettings = GetComponent<PlayerSetSettings>();
            _checkInRay = GetComponent<CheckObjectsInRay>();
            _checkShoppingList = GetComponent<CheckShoppingList>();
        }
#endif
    }
}