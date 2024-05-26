using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputReader : MonoBehaviour
    {
        [SerializeField] private PlayerSystem _playerSystem;
        [SerializeField] private CheckInventory _checkInventory;
        private PlayerMap _playerMap;
        
        private void Awake()
        {
            _playerMap = new PlayerMap();
        
            _playerMap.PlayerActionMap.Movement.performed += OnMovement;
            _playerMap.PlayerActionMap.Movement.canceled += OnMovement;

            _playerMap.PlayerActionMap.Interact.started += OnInteract;
            _playerMap.PlayerActionMap.CheckShoppingList.started += OnCheckShoppingList;
            _playerMap.PlayerActionMap.GetUp.started += OnGetUp;

            _playerMap.PlayerActionMap.CheckInventory.started += OnCheckInventory;
            _playerMap.PlayerActionMap.CheckInventory.canceled += OnCheckInventory;
        
            _playerMap.Enable();

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void OnCheckInventory(InputAction.CallbackContext obj)
        {
            _checkInventory._ToggleCheckAnimation();
        }

        // private void OnDestroy()
        // {
        //     KeysUnSubscribe();
        // }
        //
        // private void OnDisable()
        // {
        //     KeysUnSubscribe();
        // }

        private void KeysUnSubscribe()
        {
            _playerMap.PlayerActionMap.Movement.performed -= OnMovement;
            _playerMap.PlayerActionMap.Movement.canceled -= OnMovement;

            _playerMap.PlayerActionMap.Interact.started -= OnInteract;
            _playerMap.PlayerActionMap.CheckShoppingList.started -= OnCheckShoppingList;
            _playerMap.PlayerActionMap.GetUp.started -= OnGetUp;
        }

        private void OnGetUp(InputAction.CallbackContext obj)
        {
            _playerSystem.GetUp();
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
        
        public void _TogglePlayerInputMap(bool isLocked)
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