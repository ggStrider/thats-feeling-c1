using UnityEngine;

namespace InteractFeatures.Hovered
{
    public class HoveredEnableGameObject : MonoBehaviour, IHovered
    {
        [Tooltip("Leave it alone == this object")]
        [SerializeField] private GameObject _objectToEnable;

        [SerializeField] private Transform player;
        [SerializeField] private Transform _objectTolook;
        
        public void OnHovered()
        {
            _objectToEnable.SetActive(true);
            _objectTolook.LookAt(player);
        }
        
        public void NonHovered()
        {
            _objectToEnable.SetActive(false);
        }
    }
}