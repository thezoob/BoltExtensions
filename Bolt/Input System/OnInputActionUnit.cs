using Bolt;
using Lasm.OdinSerializer;
using Ludiq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
#endif

namespace Lasm.BoltExtensions
{
    /// <summary>
    /// The Event Unit for player input with the new Unity Input System.
    /// </summary>
    [TypeIcon(typeof(OnButtonInput))]
    [UnitTitle("On Input Action")]
    [UnitCategory("Events/Input/Input System")]
    public sealed class OnInputActionUnit : ManualEventUnit<NullInputEventArgs>
    {
        /// <summary>
        /// Overrides the hook name that the Event Bus calls to decipher different event types.
        /// </summary>
        protected override string hookName => "OnInputAction";

        /// <summary>
        /// The Value Input for the PlayerInput.
        /// </summary>
        [DoNotSerialize]
        [PortLabelHidden]
        [NullMeansSelf]
        [RenamedFrom("Lasm.BoltExtensions.actions")]
        public ValueInput player;

        /// <summary>
        /// The current value of the stick, button, or key being pressed.
        /// </summary>
        [DoNotSerialize]
        public ValueOutput value;

        /// <summary>
        /// The Control Output invoked when the action is performed.
        /// </summary>
        [DoNotSerialize]
        public ControlOutput performed;

#if ENABLE_INPUT_SYSTEM
        /// <summary>
        /// The asset that contains the actions we are using.
        /// </summary>
        [UnitHeaderInspectable]
        [Inspectable]
        [OdinSerialize]
        public InputActionAsset asset;

        /// <summary>
        /// How we handle the behaviour of this action. Is the stick, button, or key being pressed, was it just pressed, or was it just released?
        /// </summary>
        [UnitHeaderInspectable]
        [Inspectable]
        public InputActionStatus status;

        /// <summary>
        /// The action to check we are performing.
        /// </summary>
        [OdinSerialize]
        public InputAction action;

        /// <summary>
        /// The map that was chosen, that belongs to the current action. Used internally for editor purposes.
        /// </summary>
        [OdinSerialize]
        public InputActionMap map;

        private Action<InputAction.CallbackContext> act;
#endif

        /// <summary>
        /// The id of this action to be performed.
        /// </summary>
        public int actionId;

        private object lastValue;

        private GraphReference reference;

        private bool isPressing;

#if ENABLE_INPUT_SYSTEM
        private PlayerInput playerInput;

        private InputAction contextAction;
#endif
        protected override void Definition()
        {
#if ENABLE_INPUT_SYSTEM
            base.Definition();

            player = ValueInput<PlayerInput>("player", null).NullMeansSelf();

            if (action != null)
            {
                switch (action.expectedControlType)
                {
                    case "Any":
                        value = ValueOutput<object>("value", (flow) => { return lastValue; });
                        break;

                    case "Axis":
                        value = ValueOutput<float>("value", (flow) => { return (float)lastValue; });
                        break;

                    case "Bone":
                        value = ValueOutput<UnityEngine.XR.Bone>("value", (flow) => { return (UnityEngine.XR.Bone)lastValue; });
                        break;

                    case "Digital":
                        value = ValueOutput<double>("value", (flow) => { return (double)lastValue; });
                        break;

                    case "Double":
                        value = ValueOutput<double>("value", (flow) => { return (double)lastValue; });
                        break;

                    case "Dpad":
                        value = ValueOutput<Vector2>("value", (flow) => { return (Vector2)lastValue; });
                        break;

                    case "Euler":
                        value = ValueOutput<Vector3>("value", (flow) => { return (Vector3)lastValue; });
                        break;

                    case "Float":
                        value = ValueOutput<float>("value", (flow) => { return (float)lastValue; });
                        break;

                    case "Integer":
                        value = ValueOutput<int>("value", (flow) => { return (int)lastValue; });
                        break;

                    case "Quaternion":
                        value = ValueOutput<Quaternion>("value", (flow) => { return (Quaternion)lastValue; });
                        break;

                    case "Stick":
                        value = ValueOutput<Vector2>("value", (flow) => { return (Vector2)lastValue; });
                        break;

                    case "Touch":
                        value = ValueOutput<TouchState>("value", (flow) => { return (TouchState)lastValue; });
                        break;

                    case "Vector2":
                        value = ValueOutput<Vector2>("value", (flow) => { return (Vector2)lastValue; });
                        break;

                    case "Vector3":
                        value = ValueOutput<Vector3>("value", (flow) => { return (Vector3)lastValue; });
                        break;

                    default:
                        value = ValueOutput<object>("value", (flow) => { return lastValue; });
                        break;
                }
            }
#endif
        }

        /// <summary>
        /// Binds the performed and canceled delegate to the Units status action. Pressed, Hold, Released.
        /// </summary>
        public override void StartListening(GraphStack stack)
        {
#if ENABLE_INPUT_SYSTEM
            reference = stack.AsReference();
            var flow = Flow.New(reference);
            playerInput = flow.GetValue<PlayerInput>(player);

            if (playerInput == null) playerInput = stack.self.GetComponent<PlayerInput>();

            if (playerInput != null)
            {
                playerInput.actions[action.name].performed += Pressed; // Pressed
                playerInput.actions[action.name].canceled += Released; // Released
            }
#endif
        }

#if ENABLE_INPUT_SYSTEM
        private void Pressed(InputAction.CallbackContext context)
        {
            if (action != null)
            {
                contextAction = context.action;
                isPressing = true;

                if (status == InputActionStatus.Continuous)
                {
                    reference.component.StartCoroutine(Pressing());
                }
                else
                {
                    if (status == InputActionStatus.ValueChanged)
                    {
                        switch (action.expectedControlType)
                        {
                            case "Vector2":
                                lastValue = context.action.ReadValue<Vector2>();
                                break;

                            case "Vector3":
                                lastValue = context.action.ReadValue<Vector3>();
                                break;

                            case "Integer":
                                lastValue = context.action.ReadValue<int>();
                                break;

                            case "Float":
                                lastValue = context.action.ReadValue<float>();
                                break;

                            case "Quaternion":
                                lastValue = context.action.ReadValue<Quaternion>();
                                break;

                            case "Euler":
                                lastValue = context.action.ReadValue<Vector3>();
                                break;

                            default:
                                lastValue = context.action.ReadValueAsObject();
                                break;
                        }

                        if (coroutine)
                        {
                            Flow.New(reference).StartCoroutine(trigger);
                        }
                        else
                        {
                            Flow.New(reference).Invoke(trigger);
                        }
                    }
                }
            }
        }

        private IEnumerator Pressing()
        {
            while (isPressing)
            {
                switch (action.expectedControlType)
                {
                    case "Vector2":
                        lastValue = contextAction.ReadValue<Vector2>();
                        break;

                    case "Vector3":
                        lastValue = contextAction.ReadValue<Vector3>();
                        break;

                    case "Integer":
                        lastValue = contextAction.ReadValue<int>();
                        break;

                    case "Float":
                        lastValue = contextAction.ReadValue<float>();
                        break;

                    case "Quaternion":
                        lastValue = contextAction.ReadValue<Quaternion>();
                        break;

                    case "Euler":
                        lastValue = contextAction.ReadValue<Vector3>();
                        break;

                    default:
                        lastValue = contextAction.ReadValueAsObject();
                        break;
                }

                if (coroutine)
                {
                    Flow.New(reference).StartCoroutine(trigger);
                }
                else
                {
                    Flow.New(reference).Invoke(trigger);
                }

                yield return null;
            }
        }

        private void Released(InputAction.CallbackContext context)
        {
            if (action != null)
            {
                isPressing = false;

                if (status == InputActionStatus.Canceled)
                {
                    switch (action.expectedControlType)
                    {
                        case "Vector2":
                            lastValue = context.action.ReadValue<Vector2>();
                            break;

                        case "Vector3":
                            lastValue = context.action.ReadValue<Vector3>();
                            break;

                        case "Integer":
                            lastValue = context.action.ReadValue<int>();
                            break;

                        case "Float":
                            lastValue = context.action.ReadValue<float>();
                            break;

                        case "Quaternion":
                            lastValue = context.action.ReadValue<Quaternion>();
                            break;

                        case "Euler":
                            lastValue = context.action.ReadValue<Vector3>();
                            break;

                        default:
                            lastValue = context.action.ReadValueAsObject();
                            break;
                    }

                    if (coroutine)
                    {
                        Flow.New(reference).StartCoroutine(trigger);
                    }
                    else
                    {
                        Flow.New(reference).Invoke(trigger);
                    }
                }
            }
        }
#endif

        /// <summary>
        /// Unsubscribes Pressed() from the actions performed delegate, and Released() from the actions canceled delegate.
        /// </summary>
        /// <param name="stack"></param>
        public override void StopListening(GraphStack stack)
        {
#if ENABLE_INPUT_SYSTEM
            if (playerInput != null)
            {
                playerInput.actions[action.name].started -= Pressed;
                playerInput.actions[action.name].canceled -= Released;
            }
#endif
        }
    }

    /// <summary>
    /// The actions status type. How the action is being used.
    /// </summary>
    public enum InputActionStatus
    {
        ValueChanged,
        Continuous, 
        Canceled
    }
}