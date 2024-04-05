using UnityEngine;

namespace Player
{
    public class RestrictAnglesForPlayerCamera : MonoBehaviour
    {
        [SerializeField] private float _minHorizontal;
        [SerializeField] private float _maxHorizontal;

        [Space] [SerializeField] private float _minVertical;
        [SerializeField] private float _maxVertical;

        [Space] [SerializeField] private bool _wrapped;
        private PlayerSetSettings _playerSetSettings;
        
        private void Awake()
        {
            _playerSetSettings = FindObjectOfType<PlayerSetSettings>();
        }

        [ContextMenu("Restrict")]
        public void _Restrict()
        {
            var horizontal = new Vector2(_minHorizontal, _maxHorizontal);
            var vertical = new Vector2(_minVertical, _maxVertical);
            
            _playerSetSettings.SetRestrictXPositionCameraAngle(horizontal, vertical, _wrapped);
        }

        // треба переписати підхід  SetRestrictXPositionCameraAngle, так як воно працює не правильно
        public void _RemoveRestriction()
        {
            var horizontal = new Vector2(-180, 180);
            var vertical = new Vector2(-70, 70);
            
            _playerSetSettings.SetRestrictXPositionCameraAngle(horizontal, vertical, true);
        }
    }
}