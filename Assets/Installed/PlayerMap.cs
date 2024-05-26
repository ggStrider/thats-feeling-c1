//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Installed/PlayerMap.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerMap: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerMap"",
    ""maps"": [
        {
            ""name"": ""PlayerActionMap"",
            ""id"": ""df888eea-8402-4ced-97bd-5f9420198ee3"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""39801869-8d13-4553-b6e1-4af087e195b0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""56776513-6641-4e71-871d-57237fb1c45a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CheckShoppingList"",
                    ""type"": ""Button"",
                    ""id"": ""250656f9-f195-44a0-a812-39dcba4cead0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""GetUp"",
                    ""type"": ""Button"",
                    ""id"": ""3e52118a-3c07-44c4-9184-aec0b14a2ef7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CheckInventory"",
                    ""type"": ""Button"",
                    ""id"": ""6b835d1d-d3de-41b2-9e83-b77eef7bd207"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""4ad45231-5fca-47a9-ae6c-d3ba56806140"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9b2a8013-080d-47c3-bf50-798513367a1d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f75b6623-7603-4190-8765-8722119780ca"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3873d5c7-cd66-41f2-b5e6-f0fc5d8b0f59"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""70ddb52e-aeaf-4c7e-a308-8d8f4e3dbc07"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2d555da3-91e9-48d6-9de7-a12a99872c88"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f116dbe3-3eda-463d-af5f-67184956f95b"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CheckShoppingList"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""367397b9-1594-4c3e-8a17-aaff1790c2bb"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GetUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e92978e6-0f66-4519-8d1f-fbc8527473b8"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CheckInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""22cf94e0-b330-440e-9b18-8453d6c63c61"",
            ""actions"": [
                {
                    ""name"": ""ArrowUp"",
                    ""type"": ""Button"",
                    ""id"": ""fffa1249-87ff-4f7c-be4b-cb0250b98bc2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ArrowDown"",
                    ""type"": ""Button"",
                    ""id"": ""bb2f57b2-4f7f-494b-9bd8-17a0e2b8e787"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ArrowRight"",
                    ""type"": ""Button"",
                    ""id"": ""ae6c2ff3-be67-4006-8115-f0a08622fe98"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ArrowLeft"",
                    ""type"": ""Button"",
                    ""id"": ""dd6624cd-701f-4823-8cbb-411ceab63937"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""94f52721-f35a-44c8-bee5-aeaab6ff7b39"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b8f9a4d5-d5ed-473b-89bf-fac3dfa0f4ee"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArrowUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""308e5605-ac77-41d9-b2b2-3ea33bb9ba11"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15bca41e-55e2-431c-85c1-d22ad25b751e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArrowLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37f4d1cd-509c-4234-a0bb-2dbb598811d7"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArrowDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d365870-fc02-47a2-80b6-4c61e73caa83"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArrowRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerActionMap
        m_PlayerActionMap = asset.FindActionMap("PlayerActionMap", throwIfNotFound: true);
        m_PlayerActionMap_Movement = m_PlayerActionMap.FindAction("Movement", throwIfNotFound: true);
        m_PlayerActionMap_Interact = m_PlayerActionMap.FindAction("Interact", throwIfNotFound: true);
        m_PlayerActionMap_CheckShoppingList = m_PlayerActionMap.FindAction("CheckShoppingList", throwIfNotFound: true);
        m_PlayerActionMap_GetUp = m_PlayerActionMap.FindAction("GetUp", throwIfNotFound: true);
        m_PlayerActionMap_CheckInventory = m_PlayerActionMap.FindAction("CheckInventory", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_ArrowUp = m_UI.FindAction("ArrowUp", throwIfNotFound: true);
        m_UI_ArrowDown = m_UI.FindAction("ArrowDown", throwIfNotFound: true);
        m_UI_ArrowRight = m_UI.FindAction("ArrowRight", throwIfNotFound: true);
        m_UI_ArrowLeft = m_UI.FindAction("ArrowLeft", throwIfNotFound: true);
        m_UI_Enter = m_UI.FindAction("Enter", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerActionMap
    private readonly InputActionMap m_PlayerActionMap;
    private List<IPlayerActionMapActions> m_PlayerActionMapActionsCallbackInterfaces = new List<IPlayerActionMapActions>();
    private readonly InputAction m_PlayerActionMap_Movement;
    private readonly InputAction m_PlayerActionMap_Interact;
    private readonly InputAction m_PlayerActionMap_CheckShoppingList;
    private readonly InputAction m_PlayerActionMap_GetUp;
    private readonly InputAction m_PlayerActionMap_CheckInventory;
    public struct PlayerActionMapActions
    {
        private @PlayerMap m_Wrapper;
        public PlayerActionMapActions(@PlayerMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerActionMap_Movement;
        public InputAction @Interact => m_Wrapper.m_PlayerActionMap_Interact;
        public InputAction @CheckShoppingList => m_Wrapper.m_PlayerActionMap_CheckShoppingList;
        public InputAction @GetUp => m_Wrapper.m_PlayerActionMap_GetUp;
        public InputAction @CheckInventory => m_Wrapper.m_PlayerActionMap_CheckInventory;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionMapActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActionMapActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @CheckShoppingList.started += instance.OnCheckShoppingList;
            @CheckShoppingList.performed += instance.OnCheckShoppingList;
            @CheckShoppingList.canceled += instance.OnCheckShoppingList;
            @GetUp.started += instance.OnGetUp;
            @GetUp.performed += instance.OnGetUp;
            @GetUp.canceled += instance.OnGetUp;
            @CheckInventory.started += instance.OnCheckInventory;
            @CheckInventory.performed += instance.OnCheckInventory;
            @CheckInventory.canceled += instance.OnCheckInventory;
        }

        private void UnregisterCallbacks(IPlayerActionMapActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @CheckShoppingList.started -= instance.OnCheckShoppingList;
            @CheckShoppingList.performed -= instance.OnCheckShoppingList;
            @CheckShoppingList.canceled -= instance.OnCheckShoppingList;
            @GetUp.started -= instance.OnGetUp;
            @GetUp.performed -= instance.OnGetUp;
            @GetUp.canceled -= instance.OnGetUp;
            @CheckInventory.started -= instance.OnCheckInventory;
            @CheckInventory.performed -= instance.OnCheckInventory;
            @CheckInventory.canceled -= instance.OnCheckInventory;
        }

        public void RemoveCallbacks(IPlayerActionMapActions instance)
        {
            if (m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActionMapActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActionMapActions @PlayerActionMap => new PlayerActionMapActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    private readonly InputAction m_UI_ArrowUp;
    private readonly InputAction m_UI_ArrowDown;
    private readonly InputAction m_UI_ArrowRight;
    private readonly InputAction m_UI_ArrowLeft;
    private readonly InputAction m_UI_Enter;
    public struct UIActions
    {
        private @PlayerMap m_Wrapper;
        public UIActions(@PlayerMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @ArrowUp => m_Wrapper.m_UI_ArrowUp;
        public InputAction @ArrowDown => m_Wrapper.m_UI_ArrowDown;
        public InputAction @ArrowRight => m_Wrapper.m_UI_ArrowRight;
        public InputAction @ArrowLeft => m_Wrapper.m_UI_ArrowLeft;
        public InputAction @Enter => m_Wrapper.m_UI_Enter;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
            @ArrowUp.started += instance.OnArrowUp;
            @ArrowUp.performed += instance.OnArrowUp;
            @ArrowUp.canceled += instance.OnArrowUp;
            @ArrowDown.started += instance.OnArrowDown;
            @ArrowDown.performed += instance.OnArrowDown;
            @ArrowDown.canceled += instance.OnArrowDown;
            @ArrowRight.started += instance.OnArrowRight;
            @ArrowRight.performed += instance.OnArrowRight;
            @ArrowRight.canceled += instance.OnArrowRight;
            @ArrowLeft.started += instance.OnArrowLeft;
            @ArrowLeft.performed += instance.OnArrowLeft;
            @ArrowLeft.canceled += instance.OnArrowLeft;
            @Enter.started += instance.OnEnter;
            @Enter.performed += instance.OnEnter;
            @Enter.canceled += instance.OnEnter;
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
            @ArrowUp.started -= instance.OnArrowUp;
            @ArrowUp.performed -= instance.OnArrowUp;
            @ArrowUp.canceled -= instance.OnArrowUp;
            @ArrowDown.started -= instance.OnArrowDown;
            @ArrowDown.performed -= instance.OnArrowDown;
            @ArrowDown.canceled -= instance.OnArrowDown;
            @ArrowRight.started -= instance.OnArrowRight;
            @ArrowRight.performed -= instance.OnArrowRight;
            @ArrowRight.canceled -= instance.OnArrowRight;
            @ArrowLeft.started -= instance.OnArrowLeft;
            @ArrowLeft.performed -= instance.OnArrowLeft;
            @ArrowLeft.canceled -= instance.OnArrowLeft;
            @Enter.started -= instance.OnEnter;
            @Enter.performed -= instance.OnEnter;
            @Enter.canceled -= instance.OnEnter;
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IPlayerActionMapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnCheckShoppingList(InputAction.CallbackContext context);
        void OnGetUp(InputAction.CallbackContext context);
        void OnCheckInventory(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnArrowUp(InputAction.CallbackContext context);
        void OnArrowDown(InputAction.CallbackContext context);
        void OnArrowRight(InputAction.CallbackContext context);
        void OnArrowLeft(InputAction.CallbackContext context);
        void OnEnter(InputAction.CallbackContext context);
    }
}
