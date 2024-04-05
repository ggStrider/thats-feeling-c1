using Cinemachine;
using InteractFeatures;
using UnityEngine;

namespace Player
{
    public class PlayerSetSettings : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _vcamCinemachine;
        [field: SerializeField] public bool CanInteract { get; private set; } = true;
        public SitOnObject currentSitComponent;
            
        private Rigidbody _rigidbody;
        
        private CinemachinePOV _playerCinemachinePov;
        private CinemachineBrain _playerCinemachineBrain;
        
        #if UNITY_EDITOR
        public CinemachinePOV cmpov => _playerCinemachinePov;
        #endif

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();

            var playerSystem = GetComponent<PlayerSystem>();
            _playerCinemachineBrain = playerSystem.VisionCamera.GetComponent<CinemachineBrain>();
            
            _playerCinemachinePov = _vcamCinemachine.GetCinemachineComponent<CinemachinePOV>();
        }

        public void _CanInteract(bool canInteract)
        {
            CanInteract = canInteract;
        }
        
        /// <summary>
        /// Restrict angle for camera method
        /// </summary>
        /// <param name="minAndMaxHorizontalAngles">x = horizontal min value; y = horizontal max value</param>
        /// <param name="minAndMaxVerticalAngles">x = vertical min value; y = vertical max value</param>
        /// <param name="wrapped">is wrapped</param>
        public void SetRestrictXPositionCameraAngle(Vector2 minAndMaxHorizontalAngles, Vector2 minAndMaxVerticalAngles, bool wrapped)
        {
            _playerCinemachinePov.m_HorizontalAxis.m_MinValue = minAndMaxHorizontalAngles.x;
            _playerCinemachinePov.m_HorizontalAxis.m_MaxValue = minAndMaxHorizontalAngles.y;
            
            _playerCinemachinePov.m_VerticalAxis.m_MinValue = minAndMaxVerticalAngles.x;
            _playerCinemachinePov.m_VerticalAxis.m_MaxValue = minAndMaxVerticalAngles.y;

            _playerCinemachinePov.m_HorizontalAxis.m_Wrap = wrapped;
        }

        public void _SetCameraRotation(Vector2 lookAngle)
        {
            _playerCinemachinePov.m_HorizontalAxis.Value = lookAngle.x;
            _playerCinemachinePov.m_VerticalAxis.Value = lookAngle.y;
        }

        public void _CanCameraRotate(bool canRotate)
        {
            _playerCinemachineBrain.enabled = canRotate;
        }

        public void _OnCutSceneStarts()
        {
            _playerCinemachineBrain.enabled = false;
            _rigidbody.isKinematic = true;
        }

        public void _OnCutSceneEnds()
        {
            _playerCinemachineBrain.enabled = true;
            _rigidbody.isKinematic = false;
        }
    }
}