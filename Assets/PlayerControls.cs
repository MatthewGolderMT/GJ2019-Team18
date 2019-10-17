// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerControls : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""FullControl"",
            ""id"": ""151dc08b-1ee9-4efb-b7ab-037b3328801b"",
            ""actions"": [
                {
                    ""name"": ""Grow"",
                    ""type"": ""Button"",
                    ""id"": ""bbe7e60c-428d-43de-a32d-2787d29e6448"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""f267d56b-5ad6-4e17-a60c-8a26055cc395"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Button"",
                    ""id"": ""ef44ff56-05a4-421e-981f-6c78ce2ea215"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cc3cbcb6-6318-4f33-9052-6b0720f34bf9"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""78f66f0d-bf4f-4dca-a165-41c4f054803e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""182f3753-f1eb-4085-9191-00e980092921"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MovementControl"",
            ""id"": ""56f02f99-e90d-4981-8617-d52d3f2a71cc"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""6a3cd8b0-c2be-4b6a-a2a2-8182d46b582f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bcfef3cb-f3c3-44eb-b2ad-794981cf34dc"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ShootControl"",
            ""id"": ""82b3bdfe-2153-4ac7-a680-a32a1d3f3309"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""e08a2ce3-8f23-48c2-9864-2b0a9d45d8db"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Button"",
                    ""id"": ""b54666d4-cac8-488c-975d-4df09fda9a51"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""50f3c793-29a1-4d84-861a-a91b8b1b90ef"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""feceb917-c35b-4dbd-bc5b-1599d4f41f17"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""266a188b-9ae5-4ad6-8bf0-2b92a49dd64e"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MergeControl"",
            ""id"": ""7ef46e5a-8bcf-4b04-9d90-63b64c77dff3"",
            ""actions"": [
                {
                    ""name"": ""Merge"",
                    ""type"": ""Button"",
                    ""id"": ""864a079d-3e5d-4799-b0cd-67781970751f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Disband"",
                    ""type"": ""Button"",
                    ""id"": ""baf2546b-5cce-4a75-abf6-40ab7a6fec5c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d5f03ce9-9c7f-40a3-8e1a-64b99a0bb012"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Merge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""68060898-6c28-4a4f-8ad7-777a026b5ee0"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Disband"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""887bb753-bce3-40a0-bb82-4f4e5df5867d"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Disband"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""783e3c28-2839-42bb-bdc7-fe1622906d9c"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Disband"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // FullControl
        m_FullControl = asset.FindActionMap("FullControl", throwIfNotFound: true);
        m_FullControl_Grow = m_FullControl.FindAction("Grow", throwIfNotFound: true);
        m_FullControl_Move = m_FullControl.FindAction("Move", throwIfNotFound: true);
        m_FullControl_Rotation = m_FullControl.FindAction("Rotation", throwIfNotFound: true);
        // MovementControl
        m_MovementControl = asset.FindActionMap("MovementControl", throwIfNotFound: true);
        m_MovementControl_Move = m_MovementControl.FindAction("Move", throwIfNotFound: true);
        // ShootControl
        m_ShootControl = asset.FindActionMap("ShootControl", throwIfNotFound: true);
        m_ShootControl_Shoot = m_ShootControl.FindAction("Shoot", throwIfNotFound: true);
        m_ShootControl_Rotation = m_ShootControl.FindAction("Rotation", throwIfNotFound: true);
        // MergeControl
        m_MergeControl = asset.FindActionMap("MergeControl", throwIfNotFound: true);
        m_MergeControl_Merge = m_MergeControl.FindAction("Merge", throwIfNotFound: true);
        m_MergeControl_Disband = m_MergeControl.FindAction("Disband", throwIfNotFound: true);
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

    // FullControl
    private readonly InputActionMap m_FullControl;
    private IFullControlActions m_FullControlActionsCallbackInterface;
    private readonly InputAction m_FullControl_Grow;
    private readonly InputAction m_FullControl_Move;
    private readonly InputAction m_FullControl_Rotation;
    public struct FullControlActions
    {
        private PlayerControls m_Wrapper;
        public FullControlActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Grow => m_Wrapper.m_FullControl_Grow;
        public InputAction @Move => m_Wrapper.m_FullControl_Move;
        public InputAction @Rotation => m_Wrapper.m_FullControl_Rotation;
        public InputActionMap Get() { return m_Wrapper.m_FullControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FullControlActions set) { return set.Get(); }
        public void SetCallbacks(IFullControlActions instance)
        {
            if (m_Wrapper.m_FullControlActionsCallbackInterface != null)
            {
                Grow.started -= m_Wrapper.m_FullControlActionsCallbackInterface.OnGrow;
                Grow.performed -= m_Wrapper.m_FullControlActionsCallbackInterface.OnGrow;
                Grow.canceled -= m_Wrapper.m_FullControlActionsCallbackInterface.OnGrow;
                Move.started -= m_Wrapper.m_FullControlActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_FullControlActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_FullControlActionsCallbackInterface.OnMove;
                Rotation.started -= m_Wrapper.m_FullControlActionsCallbackInterface.OnRotation;
                Rotation.performed -= m_Wrapper.m_FullControlActionsCallbackInterface.OnRotation;
                Rotation.canceled -= m_Wrapper.m_FullControlActionsCallbackInterface.OnRotation;
            }
            m_Wrapper.m_FullControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                Grow.started += instance.OnGrow;
                Grow.performed += instance.OnGrow;
                Grow.canceled += instance.OnGrow;
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                Rotation.started += instance.OnRotation;
                Rotation.performed += instance.OnRotation;
                Rotation.canceled += instance.OnRotation;
            }
        }
    }
    public FullControlActions @FullControl => new FullControlActions(this);

    // MovementControl
    private readonly InputActionMap m_MovementControl;
    private IMovementControlActions m_MovementControlActionsCallbackInterface;
    private readonly InputAction m_MovementControl_Move;
    public struct MovementControlActions
    {
        private PlayerControls m_Wrapper;
        public MovementControlActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_MovementControl_Move;
        public InputActionMap Get() { return m_Wrapper.m_MovementControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementControlActions set) { return set.Get(); }
        public void SetCallbacks(IMovementControlActions instance)
        {
            if (m_Wrapper.m_MovementControlActionsCallbackInterface != null)
            {
                Move.started -= m_Wrapper.m_MovementControlActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_MovementControlActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_MovementControlActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_MovementControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
            }
        }
    }
    public MovementControlActions @MovementControl => new MovementControlActions(this);

    // ShootControl
    private readonly InputActionMap m_ShootControl;
    private IShootControlActions m_ShootControlActionsCallbackInterface;
    private readonly InputAction m_ShootControl_Shoot;
    private readonly InputAction m_ShootControl_Rotation;
    public struct ShootControlActions
    {
        private PlayerControls m_Wrapper;
        public ShootControlActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_ShootControl_Shoot;
        public InputAction @Rotation => m_Wrapper.m_ShootControl_Rotation;
        public InputActionMap Get() { return m_Wrapper.m_ShootControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShootControlActions set) { return set.Get(); }
        public void SetCallbacks(IShootControlActions instance)
        {
            if (m_Wrapper.m_ShootControlActionsCallbackInterface != null)
            {
                Shoot.started -= m_Wrapper.m_ShootControlActionsCallbackInterface.OnShoot;
                Shoot.performed -= m_Wrapper.m_ShootControlActionsCallbackInterface.OnShoot;
                Shoot.canceled -= m_Wrapper.m_ShootControlActionsCallbackInterface.OnShoot;
                Rotation.started -= m_Wrapper.m_ShootControlActionsCallbackInterface.OnRotation;
                Rotation.performed -= m_Wrapper.m_ShootControlActionsCallbackInterface.OnRotation;
                Rotation.canceled -= m_Wrapper.m_ShootControlActionsCallbackInterface.OnRotation;
            }
            m_Wrapper.m_ShootControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                Shoot.started += instance.OnShoot;
                Shoot.performed += instance.OnShoot;
                Shoot.canceled += instance.OnShoot;
                Rotation.started += instance.OnRotation;
                Rotation.performed += instance.OnRotation;
                Rotation.canceled += instance.OnRotation;
            }
        }
    }
    public ShootControlActions @ShootControl => new ShootControlActions(this);

    // MergeControl
    private readonly InputActionMap m_MergeControl;
    private IMergeControlActions m_MergeControlActionsCallbackInterface;
    private readonly InputAction m_MergeControl_Merge;
    private readonly InputAction m_MergeControl_Disband;
    public struct MergeControlActions
    {
        private PlayerControls m_Wrapper;
        public MergeControlActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Merge => m_Wrapper.m_MergeControl_Merge;
        public InputAction @Disband => m_Wrapper.m_MergeControl_Disband;
        public InputActionMap Get() { return m_Wrapper.m_MergeControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MergeControlActions set) { return set.Get(); }
        public void SetCallbacks(IMergeControlActions instance)
        {
            if (m_Wrapper.m_MergeControlActionsCallbackInterface != null)
            {
                Merge.started -= m_Wrapper.m_MergeControlActionsCallbackInterface.OnMerge;
                Merge.performed -= m_Wrapper.m_MergeControlActionsCallbackInterface.OnMerge;
                Merge.canceled -= m_Wrapper.m_MergeControlActionsCallbackInterface.OnMerge;
                Disband.started -= m_Wrapper.m_MergeControlActionsCallbackInterface.OnDisband;
                Disband.performed -= m_Wrapper.m_MergeControlActionsCallbackInterface.OnDisband;
                Disband.canceled -= m_Wrapper.m_MergeControlActionsCallbackInterface.OnDisband;
            }
            m_Wrapper.m_MergeControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                Merge.started += instance.OnMerge;
                Merge.performed += instance.OnMerge;
                Merge.canceled += instance.OnMerge;
                Disband.started += instance.OnDisband;
                Disband.performed += instance.OnDisband;
                Disband.canceled += instance.OnDisband;
            }
        }
    }
    public MergeControlActions @MergeControl => new MergeControlActions(this);
    public interface IFullControlActions
    {
        void OnGrow(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
    }
    public interface IMovementControlActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
    public interface IShootControlActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
    }
    public interface IMergeControlActions
    {
        void OnMerge(InputAction.CallbackContext context);
        void OnDisband(InputAction.CallbackContext context);
    }
}
