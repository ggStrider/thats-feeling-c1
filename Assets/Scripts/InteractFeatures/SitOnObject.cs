using Events;
using UnityEngine;

using Player;
using UI;

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

        [field:SerializeField, Space] public bool CanSit { private get; set; } 
        [field:SerializeField] public bool CanGetUp { private get; set; }

#if UNITY_EDITOR
        [SerializeField] private bool _connectToUnityEvent;
#endif
        
        [ContextMenu("sit")]
        public async void _Sit()
        {
            if(!CanSit) return;
            CanSit = false;
            
            ChangeState(true);
            if(_fadeOnChangeState)
                await _fader.Fade();
            
            var place = _sitPlace.position + _sitOffset;
            _player.transform.position = place;
            
            if(_fadeOnChangeState)
                await _fader.UnFade();
        }

        [ContextMenu("getup")]
        public async void GetUp()
        {
            if(!CanGetUp) return;
            CanGetUp = false;
            
            ChangeState(false);
            if(_fadeOnChangeState)
                await _fader.Fade();
            
            var place = _getUpPlace.position + _getUpOffset;
            _player.transform.position = place;
            
            if(_fadeOnChangeState)
                await _fader.UnFade();
        }

        private void ChangeState(bool isSitState)
        {
            var inputReader = _player.GetComponent<PlayerInputReader>();
            inputReader.RestrictMoving(isSitState);

            _player.GetComponent<Rigidbody>().isKinematic = isSitState;
        }
        
#if  UNITY_EDITOR
        private void OnValidate()
        {
            _player = GameObject.FindGameObjectWithTag("Player");

            if (!_connectToUnityEvent) return;
            
            var unityEvent = GetComponent<InvokeUnityEvent>();
            unityEvent.unityEvent.RemoveListener(_Sit);
            unityEvent.unityEvent.AddListener(_Sit);
        }
#endif
    }
}