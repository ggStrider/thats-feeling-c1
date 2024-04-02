using UnityEngine;
using Events;
using System.Threading.Tasks;

namespace InteractFeatures
{
    public class RotateObject : MonoBehaviour
    {
        [Tooltip("Leave it alone = this game object")] [SerializeField]
        private Transform _objectToRotate;

        [Space] [SerializeField] private Vector3 _rotateDelta;
        [SerializeField] private float _durationDelta;

        [Header("In milliseconds (int)")] [SerializeField]
        private int _delayBetweenUsing;

        [Space] [SerializeField] private bool _isLever;
        [SerializeField] private bool _canUse = true;

        [SerializeField] private bool _onRotatedPosition;

        [Space] [SerializeField] private InvokeUnityEvent _onRotated;
        [SerializeField] private InvokeUnityEvent _onBackToStartPosition;

        public bool Rotated => _onRotatedPosition;

        private void Awake()
        {
            if (_objectToRotate != null) return;
            _objectToRotate = transform;
        }

        public async void _OnRotate()
        {
            if (!_canUse) return;

            if (_isLever)
            {
                _canUse = false;
                await Rotate();

                _onRotatedPosition = !_onRotatedPosition;
                DelayUsing();
            }
            else
            {
                _canUse = false;
                await Rotate();
            }
        }

        private async Task Rotate()
        {
            var targetRotation = _onRotatedPosition ? -_rotateDelta : _rotateDelta;
            var newRotation = _objectToRotate.localRotation.eulerAngles + targetRotation;

            var elapsedTime = .0f;

            while (elapsedTime < _durationDelta)
            {
                _objectToRotate.localRotation = Quaternion.Slerp(_objectToRotate.localRotation,
                    Quaternion.Euler(newRotation), elapsedTime / _durationDelta);
                elapsedTime += Time.deltaTime;

                if (Quaternion.Angle(_objectToRotate.localRotation, Quaternion.Euler(newRotation)) < 0.1f)
                    elapsedTime = _durationDelta;

                await Task.Yield();
            }

            _objectToRotate.localRotation = Quaternion.Euler(newRotation);

            (_onRotatedPosition ? _onBackToStartPosition : _onRotated)?._InvokeEvent();
        }

        private async void DelayUsing()
        {
            await Task.Delay(_delayBetweenUsing);
            _canUse = true;
        }
    }
}