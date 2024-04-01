using UnityEngine;

namespace Player
{
    public class RestrictAnglesForPlayerCamera : MonoBehaviour
    {
        [SerializeField] private Vector2 _minAngles;
        [SerializeField] private Vector2 _maxAngles;

        [Space] [SerializeField] private bool _wrapped;
        private PlayerSetSettings _playerSetSettings;

        private void Awake()
        {
            _playerSetSettings = FindObjectOfType<PlayerSetSettings>();
        }

        [ContextMenu("Restrict")]
        public void _Restrict()
        {
            _playerSetSettings.SetRestrictXPositionCameraAngle(_minAngles, _maxAngles, _wrapped);
        }

        // треба переписати підхід  SetRestrictXPositionCameraAngle, так як воно працює не правильно
        public void _DeleteAllRestrict()
        {
            var resetVertical = new Vector2(-70, 70);
            var resetHorizontal = new Vector2(-180, 180);
            _playerSetSettings.SetRestrictXPositionCameraAngle(_minAngles, _maxAngles, true);
        }
    }
}