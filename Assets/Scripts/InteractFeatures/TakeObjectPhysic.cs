using UnityEngine;

namespace InteractFeatures
{
    public class TakeObjectPhysic : MonoBehaviour
    {
        [SerializeField] private Transform _place;

        public void _Bind()
        {
            transform.parent = _place;
            transform.localPosition = _place.localPosition;
        }

        [ContextMenu("un")]
        public void _UnBind()
        {
            transform.parent = null;
        }
    }
}