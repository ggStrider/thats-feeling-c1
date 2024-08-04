using UnityEngine;

using InteractFeatures.Hovered;
using InteractFeatures.Interact;

namespace Player
{
    [RequireComponent(typeof(PlayerSetSettings))]
    [RequireComponent(typeof(CheckObjectsInRay))]
    [RequireComponent(typeof(PlayerInputReader))]
    public class PlayerSystem : MonoBehaviour
    {
        [SerializeField] private float _maxSpeed = 6;
        
        /// <summary>
        /// at what speed will the current speed (_currentSpeed)
        /// change after the start of the movement to the maximum speed (_maxSpeed)
        /// </summary>
        [SerializeField] private float _changeSpeedDelta = 0.7f;
        
        [SerializeField] private float _currentSpeed;
        [SerializeField] private float _rayCheckDistance;

        [field:SerializeField] public Camera VisionCamera { get; private set; }
        [SerializeField] private CheckObjectsInRay _checkInRay;

        [Space] [Header("Camera Bobbing")]
        [SerializeField] private Transform _cameraParent;
        [SerializeField, Range(0, 1)] private float _bobbingHeight;
        [SerializeField] private float _bobbingFrequency;
        [SerializeField] private float _sinusValueForBobbing;
        
        [Space] [SerializeField] private CheckShoppingList _checkShoppingList;
        
        private PlayerSetSettings _playerSetSettings;
        [SerializeField] private Rigidbody _rigidbody;

        private Vector2 _direction;
        private IHovered _lastHoveredObject;

        private void Start()
        {
            _checkInRay = GetComponent<CheckObjectsInRay>();
            _rigidbody = GetComponent<Rigidbody>();
            _playerSetSettings = GetComponent<PlayerSetSettings>();
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;

            if (direction == Vector2.zero) _currentSpeed = 0;
        }
        
        public void Interact()
        {
            if (!_playerSetSettings.CanInteract) return;

            var playerCamera = VisionCamera.transform;
            var result = _checkInRay.Check(playerCamera.position,
                playerCamera.forward, _rayCheckDistance);

            if (result == null) return;
            var interactObject = result.GetComponent<IInteract>();

            interactObject?.Interact();
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
            if (_direction != Vector2.zero)
            {
                _currentSpeed = Mathf.Clamp(_currentSpeed + _changeSpeedDelta, 0, _maxSpeed);

                _sinusValueForBobbing += Time.fixedDeltaTime;
                if (_sinusValueForBobbing >= Mathf.PI * 2) _sinusValueForBobbing = 0;
            }
            var bobbingSinusValue = _bobbingHeight * Mathf.Sin(_sinusValueForBobbing * _bobbingFrequency);
            _cameraParent.localPosition = Vector3.up * bobbingSinusValue;
            
            var cameraForward = VisionCamera.transform.forward;
            cameraForward.y = 0;
            cameraForward.Normalize();

            var movementDirection = cameraForward * _direction.y + VisionCamera.transform.right * _direction.x;
            movementDirection.Normalize();

            var velocity = movementDirection * _currentSpeed;
            
            _rigidbody.velocity = new Vector3(velocity.x, _rigidbody.velocity.y, velocity.z);

            Debug.DrawRay(VisionCamera.transform.position, VisionCamera.transform.forward * _rayCheckDistance,
                Color.green);
        }

        private void Update()
        {
            if (!Physics.Raycast(VisionCamera.transform.position, VisionCamera.transform.forward, out var hit,
                    _rayCheckDistance))
            {
                if (_lastHoveredObject == null) return;
                NonHoveredOnLastObject();
                return;
            }

            if (!hit.transform.gameObject.CompareTag("RayHovered"))
            {
                if (_lastHoveredObject == null) return;
                NonHoveredOnLastObject();
            }
            
            _lastHoveredObject = hit.transform.gameObject.GetComponent<IHovered>();
            _lastHoveredObject?.OnHovered();
        }

        private void NonHoveredOnLastObject()
        {
            _lastHoveredObject.NonHovered();
            _lastHoveredObject = null;
        }
    }
}