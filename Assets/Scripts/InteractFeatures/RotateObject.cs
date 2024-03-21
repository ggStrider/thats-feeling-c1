using UnityEngine;
using System.Threading.Tasks;

namespace InteractFeatures
{
    public class RotateObject : MonoBehaviour
    {
        [Tooltip("Leave it alone = this game object")]
        [SerializeField] private Transform _objectToRotate;

        [Space] [SerializeField] private Vector3 _rotateDelta;
        [SerializeField] private float _durationDelta;
        
        [Header("In milliseconds")]
        [SerializeField] private int _delayBetweenUsing;

        [Space] [SerializeField] private bool _isLever;
        [SerializeField] private bool _canUse = true;
        
        [SerializeField] private bool _onRotatedPosition;

        private void Awake()
        {
            if(_objectToRotate != null) return;
            _objectToRotate = transform;
        }

        public async void _OnRotate()
        {
            if(!_canUse) return;
            
            if (_isLever)
            {
                _canUse = false;
                await Rotate(!_onRotatedPosition);

                _onRotatedPosition = !_onRotatedPosition;
                DelayUsing();
            }
            else
            {
                _canUse = false;
                await Rotate(!_onRotatedPosition);
            }
        }

        private async Task Rotate(bool rotateToMainDelta)
        {
            var rotatePath = _rotateDelta;
            if (!rotateToMainDelta)
                rotatePath = -_rotateDelta;
            
            
            var newRotation = _objectToRotate.localRotation.eulerAngles + rotatePath;
            var elapsedTime = .0f;
            
            while (elapsedTime < _durationDelta)
            {
                _objectToRotate.localRotation = Quaternion.Slerp(_objectToRotate.rotation,
                    Quaternion.Euler(newRotation), elapsedTime / _durationDelta);
                elapsedTime += Time.deltaTime;

                await Task.Yield();
            }

            _objectToRotate.rotation = Quaternion.Euler(newRotation);
        }

        private async void DelayUsing()
        {
            await Task.Delay(_delayBetweenUsing);
            _canUse = true;
        }
    }
}