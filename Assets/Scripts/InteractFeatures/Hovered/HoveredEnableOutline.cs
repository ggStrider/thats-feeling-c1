using UnityEngine;

namespace InteractFeatures.Hovered
{
    public class HoveredEnableOutline : MonoBehaviour, IHovered
    {
        [Tooltip("Leave it alone == this object")]
        [SerializeField] private Outline _objectToOutline;

        private void Start()
        {
            if (_objectToOutline != null) return;
            _objectToOutline = GetComponent<Outline>();
        }

        public void OnHovered()
        {
            _objectToOutline.enabled = true;
        }

        public void NonHovered()
        {
            _objectToOutline.enabled = false;
        }
    }
}