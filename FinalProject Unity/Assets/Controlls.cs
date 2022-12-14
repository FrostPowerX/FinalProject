//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Controlls.inputactions
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

public partial class @Controlls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controlls"",
    ""maps"": [
        {
            ""name"": ""OnFoot"",
            ""id"": ""edda4456-489b-4c84-8502-5f03aa7f3b17"",
            ""actions"": [
                {
                    ""name"": ""MoveX"",
                    ""type"": ""Button"",
                    ""id"": ""eac483aa-b9b4-4dad-a519-3df4c9467ee1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveZ"",
                    ""type"": ""Button"",
                    ""id"": ""7a70d9bd-65d2-4b5d-8084-eb2bf8a3ba70"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseLook"",
                    ""type"": ""Value"",
                    ""id"": ""6ecbc653-78da-4119-bff7-c7cb6db89bcb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""2cea54fe-9091-4501-a32d-2d837871e5f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Bend"",
                    ""type"": ""Button"",
                    ""id"": ""84912578-cd8b-404e-8834-485423980353"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""5c967d47-bbba-4d49-8ae1-4f81302ed509"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Secondary"",
                    ""type"": ""Button"",
                    ""id"": ""b2ab3133-48ea-424d-a68f-238aecfc7a70"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6e3ce176-90ca-4abe-af21-4d39dcaba801"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""0d7c16a7-2b03-4736-ae6d-885e7dc1376b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""6379d9ac-ba8b-45d7-8669-d1c7f61effd8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Weapon1"",
                    ""type"": ""Button"",
                    ""id"": ""c793c0db-c33c-4048-99fa-f92d0750d3f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Weapon2"",
                    ""type"": ""Button"",
                    ""id"": ""82047111-e14d-4b51-83ed-6b01ed25e6cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Weapon3"",
                    ""type"": ""Button"",
                    ""id"": ""2565e8c9-4880-4f73-85bd-41f0f06625ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""d0c8a8eb-fa4a-4775-b711-b6a26c347b20"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DropWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""85d507d9-aed1-403c-bc6b-556773e202f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""X"",
                    ""id"": ""1b989e87-12ee-479d-8734-7bda6eee232c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7408f125-0cff-4783-b549-358952b7f95e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""881c5b79-ffeb-4465-95bd-64ea51a6effa"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""76b8feee-f081-4bcc-9ce6-21e4ca50bab3"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e07708d2-4709-4936-97a3-c2693b2da490"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20a341ce-2d66-41c0-b69d-43784cbf6ab3"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bend"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e1ca924-b6a7-47c1-95c0-c1689b03dd1e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7bbe55f-575e-4c25-bf70-b0401906b1d6"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Secondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Z"",
                    ""id"": ""1b19d709-f05d-4083-86b1-3600c90df8c0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveZ"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""cf21c5c4-a7fd-4942-82c1-be8f5187fc5b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveZ"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""299c5194-58f4-4146-af1c-9fcb11f7c963"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveZ"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""366944ef-94ec-41fb-8204-8edead55f5cb"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8795a8f0-10ed-4f9d-b3fb-50c6a5bf9739"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3da149d5-2c0e-4449-808a-825e8da92b32"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""839df8c9-adbb-4ec4-a263-7c941874a32d"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Weapon1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ab23a55-a351-46d8-ac22-274e3eb6381c"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Weapon2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ab51c63-3af1-49c7-a17b-1b9ed3793961"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Weapon3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29b53197-ecb2-4f60-8052-e69354e7b98a"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c2274d6-f4c5-4c81-a79b-0ea06664e3bf"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DropWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // OnFoot
        m_OnFoot = asset.FindActionMap("OnFoot", throwIfNotFound: true);
        m_OnFoot_MoveX = m_OnFoot.FindAction("MoveX", throwIfNotFound: true);
        m_OnFoot_MoveZ = m_OnFoot.FindAction("MoveZ", throwIfNotFound: true);
        m_OnFoot_MouseLook = m_OnFoot.FindAction("MouseLook", throwIfNotFound: true);
        m_OnFoot_Jump = m_OnFoot.FindAction("Jump", throwIfNotFound: true);
        m_OnFoot_Bend = m_OnFoot.FindAction("Bend", throwIfNotFound: true);
        m_OnFoot_Shoot = m_OnFoot.FindAction("Shoot", throwIfNotFound: true);
        m_OnFoot_Secondary = m_OnFoot.FindAction("Secondary", throwIfNotFound: true);
        m_OnFoot_Run = m_OnFoot.FindAction("Run", throwIfNotFound: true);
        m_OnFoot_Interaction = m_OnFoot.FindAction("Interaction", throwIfNotFound: true);
        m_OnFoot_Back = m_OnFoot.FindAction("Back", throwIfNotFound: true);
        m_OnFoot_Weapon1 = m_OnFoot.FindAction("Weapon1", throwIfNotFound: true);
        m_OnFoot_Weapon2 = m_OnFoot.FindAction("Weapon2", throwIfNotFound: true);
        m_OnFoot_Weapon3 = m_OnFoot.FindAction("Weapon3", throwIfNotFound: true);
        m_OnFoot_Reload = m_OnFoot.FindAction("Reload", throwIfNotFound: true);
        m_OnFoot_DropWeapon = m_OnFoot.FindAction("DropWeapon", throwIfNotFound: true);
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

    // OnFoot
    private readonly InputActionMap m_OnFoot;
    private IOnFootActions m_OnFootActionsCallbackInterface;
    private readonly InputAction m_OnFoot_MoveX;
    private readonly InputAction m_OnFoot_MoveZ;
    private readonly InputAction m_OnFoot_MouseLook;
    private readonly InputAction m_OnFoot_Jump;
    private readonly InputAction m_OnFoot_Bend;
    private readonly InputAction m_OnFoot_Shoot;
    private readonly InputAction m_OnFoot_Secondary;
    private readonly InputAction m_OnFoot_Run;
    private readonly InputAction m_OnFoot_Interaction;
    private readonly InputAction m_OnFoot_Back;
    private readonly InputAction m_OnFoot_Weapon1;
    private readonly InputAction m_OnFoot_Weapon2;
    private readonly InputAction m_OnFoot_Weapon3;
    private readonly InputAction m_OnFoot_Reload;
    private readonly InputAction m_OnFoot_DropWeapon;
    public struct OnFootActions
    {
        private @Controlls m_Wrapper;
        public OnFootActions(@Controlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveX => m_Wrapper.m_OnFoot_MoveX;
        public InputAction @MoveZ => m_Wrapper.m_OnFoot_MoveZ;
        public InputAction @MouseLook => m_Wrapper.m_OnFoot_MouseLook;
        public InputAction @Jump => m_Wrapper.m_OnFoot_Jump;
        public InputAction @Bend => m_Wrapper.m_OnFoot_Bend;
        public InputAction @Shoot => m_Wrapper.m_OnFoot_Shoot;
        public InputAction @Secondary => m_Wrapper.m_OnFoot_Secondary;
        public InputAction @Run => m_Wrapper.m_OnFoot_Run;
        public InputAction @Interaction => m_Wrapper.m_OnFoot_Interaction;
        public InputAction @Back => m_Wrapper.m_OnFoot_Back;
        public InputAction @Weapon1 => m_Wrapper.m_OnFoot_Weapon1;
        public InputAction @Weapon2 => m_Wrapper.m_OnFoot_Weapon2;
        public InputAction @Weapon3 => m_Wrapper.m_OnFoot_Weapon3;
        public InputAction @Reload => m_Wrapper.m_OnFoot_Reload;
        public InputAction @DropWeapon => m_Wrapper.m_OnFoot_DropWeapon;
        public InputActionMap Get() { return m_Wrapper.m_OnFoot; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OnFootActions set) { return set.Get(); }
        public void SetCallbacks(IOnFootActions instance)
        {
            if (m_Wrapper.m_OnFootActionsCallbackInterface != null)
            {
                @MoveX.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMoveX;
                @MoveX.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMoveX;
                @MoveX.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMoveX;
                @MoveZ.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMoveZ;
                @MoveZ.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMoveZ;
                @MoveZ.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMoveZ;
                @MouseLook.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMouseLook;
                @MouseLook.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMouseLook;
                @MouseLook.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMouseLook;
                @Jump.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnJump;
                @Bend.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnBend;
                @Bend.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnBend;
                @Bend.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnBend;
                @Shoot.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnShoot;
                @Secondary.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnSecondary;
                @Secondary.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnSecondary;
                @Secondary.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnSecondary;
                @Run.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnRun;
                @Interaction.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnInteraction;
                @Interaction.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnInteraction;
                @Interaction.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnInteraction;
                @Back.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnBack;
                @Weapon1.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnWeapon1;
                @Weapon1.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnWeapon1;
                @Weapon1.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnWeapon1;
                @Weapon2.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnWeapon2;
                @Weapon2.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnWeapon2;
                @Weapon2.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnWeapon2;
                @Weapon3.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnWeapon3;
                @Weapon3.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnWeapon3;
                @Weapon3.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnWeapon3;
                @Reload.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnReload;
                @DropWeapon.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnDropWeapon;
                @DropWeapon.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnDropWeapon;
                @DropWeapon.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnDropWeapon;
            }
            m_Wrapper.m_OnFootActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveX.started += instance.OnMoveX;
                @MoveX.performed += instance.OnMoveX;
                @MoveX.canceled += instance.OnMoveX;
                @MoveZ.started += instance.OnMoveZ;
                @MoveZ.performed += instance.OnMoveZ;
                @MoveZ.canceled += instance.OnMoveZ;
                @MouseLook.started += instance.OnMouseLook;
                @MouseLook.performed += instance.OnMouseLook;
                @MouseLook.canceled += instance.OnMouseLook;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Bend.started += instance.OnBend;
                @Bend.performed += instance.OnBend;
                @Bend.canceled += instance.OnBend;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Secondary.started += instance.OnSecondary;
                @Secondary.performed += instance.OnSecondary;
                @Secondary.canceled += instance.OnSecondary;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Interaction.started += instance.OnInteraction;
                @Interaction.performed += instance.OnInteraction;
                @Interaction.canceled += instance.OnInteraction;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Weapon1.started += instance.OnWeapon1;
                @Weapon1.performed += instance.OnWeapon1;
                @Weapon1.canceled += instance.OnWeapon1;
                @Weapon2.started += instance.OnWeapon2;
                @Weapon2.performed += instance.OnWeapon2;
                @Weapon2.canceled += instance.OnWeapon2;
                @Weapon3.started += instance.OnWeapon3;
                @Weapon3.performed += instance.OnWeapon3;
                @Weapon3.canceled += instance.OnWeapon3;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @DropWeapon.started += instance.OnDropWeapon;
                @DropWeapon.performed += instance.OnDropWeapon;
                @DropWeapon.canceled += instance.OnDropWeapon;
            }
        }
    }
    public OnFootActions @OnFoot => new OnFootActions(this);
    public interface IOnFootActions
    {
        void OnMoveX(InputAction.CallbackContext context);
        void OnMoveZ(InputAction.CallbackContext context);
        void OnMouseLook(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnBend(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnSecondary(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnWeapon1(InputAction.CallbackContext context);
        void OnWeapon2(InputAction.CallbackContext context);
        void OnWeapon3(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnDropWeapon(InputAction.CallbackContext context);
    }
}
