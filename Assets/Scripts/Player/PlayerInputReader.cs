using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputReader : MonoBehaviour
    {
        [SerializeField] private PlayerSystem _playerSystem;
        private PlayerMap _playerMap;
        
        private void Awake()
        {
            _playerMap = new PlayerMap();
        
            _playerMap.PlayerActionMap.Movement.performed += OnMovement;
            _playerMap.PlayerActionMap.Movement.canceled += OnMovement;

            _playerMap.PlayerActionMap.Interact.started += OnInteract;
            _playerMap.PlayerActionMap.CheckShoppingList.started += OnCheckShoppingList;
        
            _playerMap.Enable();

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void OnCheckShoppingList(InputAction.CallbackContext context)
        {
            _playerSystem.CheckShoppingList();
        }
        
        private void OnMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            _playerSystem.SetDirection(direction);
        }
        
        private void OnInteract(InputAction.CallbackContext context)
        {
            _playerSystem.Interact();
        }
        
        public void SetLock(bool isLocked)
        {
            if (isLocked)
            {
                _playerMap.Disable();
            }
        
            else
            {
                _playerMap.Enable();
            }
        }
        
        public void RestrictMoving(bool isRestricted)
        {
            if (isRestricted)
            {
                _playerMap.PlayerActionMap.Movement.performed -= OnMovement;
                _playerMap.PlayerActionMap.Movement.canceled -= OnMovement;
            }
            else
            {
                _playerMap.PlayerActionMap.Movement.performed += OnMovement;
                _playerMap.PlayerActionMap.Movement.canceled += OnMovement;
            }
        }
        
        #if UNITY_EDITOR
        private void OnValidate()
        {
            _playerSystem = GetComponent<PlayerSystem>();
        }
#endif
    }
}