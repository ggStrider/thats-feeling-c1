using UnityEngine;

using Cinemachine;

namespace CutSceneComponents
{
    public class PlayerCutSceneController : MonoBehaviour
    {
        [SerializeField] private Transform _playerStuffObject;
        [SerializeField] private bool _cutSceneOnStart;
        [SerializeField] private GameObject _playerSystemObject;
        
        [SerializeField] private Rigidbody _rigidbody;
        private CinemachineBrain _cinemachineBrain;

        private void Awake()
        {
            _rigidbody = GetComponentInChildren<Rigidbody>();
            _cinemachineBrain = GetComponentInChildren<CinemachineBrain>();
            _playerSystemObject = GameObject.FindGameObjectWithTag("Player");
            
            if(!_cutSceneOnStart) return;
            _OnCutSceneStarts();
        }

        public void _OnCutSceneStarts()
        {
            _rigidbody.isKinematic = true;
            _cinemachineBrain.enabled = false;

            _OnCutSceneInThisPosition();
        }

        public void _OnCutSceneEnds()
        {
            _rigidbody.isKinematic = false;
            _cinemachineBrain.enabled = true;

            _OnCurrentPositionCutSceneEnds();
        }

        [ContextMenu("cutscenehere")]
        public void _OnCutSceneInThisPosition()
        {
            var offsetObjectPosition = transform.localPosition;
            var playerPosition = _playerSystemObject.transform.localPosition;

            var parent = new GameObject("TempForCutScene")
            {
                transform =
                {
                    position = offsetObjectPosition + playerPosition
                }
            };
            
            transform.parent = parent.transform;
            
            transform.localPosition = Vector3.zero;
            _playerSystemObject.transform.localPosition = Vector3.zero;
        }

        public void _OnCurrentPositionCutSceneEnds()
        {
            var parent = transform.parent;
            var parentPosition = transform.parent.localPosition;
            transform.parent = null;

            transform.localPosition = parentPosition;
            
            Destroy(parent.gameObject);
        }
    }
}