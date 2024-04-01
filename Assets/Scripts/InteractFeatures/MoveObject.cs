    using System.Threading.Tasks;
using UnityEngine;

namespace InteractFeatures
{
    public class MoveObject : MonoBehaviour
    {
        [Tooltip("Leave it alone = this object")]
        [SerializeField] private Transform _objectToMove;

        [SerializeField] private Vector3 _path;
        [SerializeField] private float _moveDeltaDuration;
        [SerializeField] private bool _isLever;
        
        [Space] [Header("Delay in milliseconds")] 
        [SerializeField] private int _delayBetweenUsing; 

        [SerializeField] private bool _onStartPosition = true;
        [SerializeField] private bool _canUse = true;

        private const float Threshold = 0.005f;
        
        private void Awake()
        {
            if (_objectToMove != null) return;
            _objectToMove = transform;
        }

        [ContextMenu("move")]
        public async void _Move()
        {
            if(!_canUse) return;
            
            if (_isLever)
            {
                _canUse = false;
                await Move();

                _onStartPosition = !_onStartPosition;
                DelayUsing();
            }
            else
            {
                _canUse = false;
                await Move();
            }
        }

        private async Task Move()
        {
            var path = _onStartPosition ? _path : -_path;
                
            var newPosition = _objectToMove.localPosition + path;
            var elapsedTime = .0f;
            
            while (elapsedTime < _moveDeltaDuration)
            {
                _objectToMove.localPosition = Vector3.Lerp(_objectToMove.localPosition, newPosition, elapsedTime / _moveDeltaDuration);
                elapsedTime += Time.deltaTime;

                if (Vector3.Distance(_objectToMove.localPosition, newPosition) < Threshold)
                {
                    elapsedTime = _moveDeltaDuration;
                }

                Debug.Log(elapsedTime);
                
                await Task.Yield();
            }

            _objectToMove.localPosition = newPosition;
        }

        private async void DelayUsing()
        {
            await Task.Delay(_delayBetweenUsing);
            _canUse = true;
        }
    }
}