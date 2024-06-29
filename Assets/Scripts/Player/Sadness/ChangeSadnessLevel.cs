using UnityEngine;

namespace Player.Sadness
{
    public class ChangeSadnessLevel : MonoBehaviour
    {
        [SerializeField] private float _changeDelta;
        
        [Space] [Header("For smooth changing")]
        [SerializeField] private float _duration;
        [SerializeField] private AnimationCurve _speedCurve;
        
        private SadnessManager _sadnessManager;

        private void Start()
        {
            _sadnessManager = FindObjectOfType<SadnessManager>();
        }

        public void _ChangeSadnessLevelInstant()
        {
            _sadnessManager.ChangeSadness(_changeDelta);
        }
        
        [ContextMenu("Change")]
        public void _ChangeSadnessLevelSmooth()
        {
            StartCoroutine(_sadnessManager.ChangeSadnessSmoothly(_changeDelta, _duration, _speedCurve));
        }
    }
}