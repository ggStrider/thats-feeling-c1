using UnityEngine;

namespace Player
{
    public class CheckInventory : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private bool _isChecking;
        
        private static readonly int IsCheckingKey = Animator.StringToHash("is-checking");

        public void _ToggleCheckAnimation()
        {
            _isChecking = !_isChecking;
            _animator.SetBool(IsCheckingKey, _isChecking);

            if (_isChecking)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}