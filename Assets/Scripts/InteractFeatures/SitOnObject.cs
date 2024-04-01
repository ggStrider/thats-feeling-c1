using UnityEngine;

using Player;
using UI;
using UnityEngine.Events;

namespace InteractFeatures
{
    public class SitOnObject : MonoBehaviour
    {
        [Header("Sit/get up place settings")]
        [SerializeField] private Transform _sitPlace;
        [SerializeField] private Vector3 _sitOffset;

        [Space] [SerializeField] private Transform _getUpPlace;
        [SerializeField] private Vector3 _getUpOffset;
        
        [Space] [SerializeField] private GameObject _player;
        
        [SerializeField] private bool _fadeOnChangeState;
        [SerializeField] private Fader _fader;

        [Space] [SerializeField] private bool _canSit;
        [SerializeField] private bool _canGetUp;

        [Space] [SerializeField] private float _fadeSpeed;
        [SerializeField] private float _unFadeSpeed;

        [SerializeField] private UnityEvent _onGetUp;
        
        [ContextMenu("sit")]
        public async void _Sit()
        {
            if(!_canSit) return;
            _canSit = false;

            var playerSetSettings = FindObjectOfType<PlayerSetSettings>();
            playerSetSettings.currentSitComponent = this;
            
            ChangeState(true);
            if(_fadeOnChangeState)
                await _fader.Fade(_fadeSpeed);
            
            var place = _sitPlace.position + _sitOffset;
            _player.transform.position = place;
            
            if(_fadeOnChangeState)
                await _fader.UnFade(_unFadeSpeed);
        }

        [ContextMenu("getup")]
        public async void GetUp()
        {
            if(!_canGetUp) return;
            _canGetUp = false;

            var playerSetSettings = FindObjectOfType<PlayerSetSettings>();
            playerSetSettings.currentSitComponent = null;
            
            if(_fadeOnChangeState)
                await _fader.Fade(_fadeSpeed);
            
            var place = _getUpPlace.position + _getUpOffset;
            _player.transform.position = place;
            
            ChangeState(false);
            
            if(_fadeOnChangeState)
                await _fader.UnFade(_unFadeSpeed);
            
            _onGetUp?.Invoke();
        }

        private void ChangeState(bool isSitState)
        {
            var inputReader = _player.GetComponent<PlayerInputReader>();
            inputReader.RestrictMoving(isSitState);

            _player.GetComponent<Rigidbody>().isKinematic = isSitState;
        }

        public void SetCanSit(bool canSit)
        {
            _canSit = canSit;
        }

        public void SetCanGetUp(bool canGetUp)
        {
            _canGetUp = canGetUp;
        }
        
#if  UNITY_EDITOR
        private void OnValidate()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }
#endif
    }
}