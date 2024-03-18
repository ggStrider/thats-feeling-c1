using Cinemachine;
using UnityEngine;

namespace Player
{
    public class PlayerSetSettings : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _vcamCinemachine;
        [field: SerializeField] public bool CanInteract { get; private set; } = true; 
            
        private Rigidbody _rigidbody;
        
        private CinemachinePOV _playerCinemachinePov;
        private CinemachineBrain _playerCinemachineBrain;

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
        
        public void _SetRestrictXPositionCameraAngle(Vector2 minAngles, Vector2 maxAngles, bool wrapped)
        {
            _playerCinemachinePov.m_HorizontalAxis.m_MinValue = minAngles.x;
            _playerCinemachinePov.m_VerticalAxis.m_MinValue = minAngles.y;
            
            _playerCinemachinePov.m_HorizontalAxis.m_MaxValue = maxAngles.x;
            _playerCinemachinePov.m_VerticalAxis.m_MaxValue = maxAngles.y;

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