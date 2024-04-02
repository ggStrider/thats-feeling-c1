using UnityEngine;

namespace InteractFeatures
{
    public class CloseObjectWhenUnRotated : MonoBehaviour
    {
        [SerializeField] private MoveObject _objectToClose;
        [SerializeField] private RotateObject _objectToCheck;

        private void Awake()
        {
            if(_objectToClose != null) return;
            _objectToClose = GetComponent<MoveObject>();
        }

        public void CheckAndClose()
        {
            if (_objectToClose.IsOnStartPosition) return;
            if (_objectToCheck.Rotated) return;
            _objectToClose._Move(true);
        }
    }
}