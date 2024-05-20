using UnityEngine;

namespace InteractFeatures
{
    public class ShowTextOnHovered : MonoBehaviour
    {
        [SerializeField] private Transform _targetToLookAt;

        [SerializeField] private bool _hovered;

        private void Update()
        {
            if(!_hovered) return;
            transform.LookAt(_targetToLookAt);
        }
    }
}