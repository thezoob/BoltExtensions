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

        private Type expectedType;

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
                        value = ValueOutput<object>("value", (flow) =>
                        {
                            return lastValue == null ? action.activeControl?.ReadDefaultValueAsObject() : lastValue;
                        });
                        break;

                    case "Axis":
                        value = ValueOutput<float>("value", (flow) =>
                        {
                            return lastValue == null ? 0f : (float)lastValue;
                        });
                        break;

                    case "Bone":
                        value = ValueOutput<UnityEngine.XR.Bone>("value", (flow) =>
                        {
                            return lastValue == null ? (UnityEngine.XR.Bone)typeof(UnityEngine.XR.Bone).Default() : (UnityEngine.XR.Bone)lastValue;
                        });
                        break;

                    case "Button":
                        value = ValueOutput<float>("value", (flow) =>
                        {
                            return lastValue == null ? 0f : (float)lastValue;
                        });
                        break;

                    case "Digital":
                        value = ValueOutput<double>("value", (flow) =>
                        {
                            return lastValue == null ? 0f : (float)lastValue;
                        });
                        break;

                    case "Double":
                        value = ValueOutput<float>("value", (flow) =>
                        {
                            return lastValue == null ? 0f : (float)lastValue;
                        });
                        break;

                    case "Dpad":
                        value = ValueOutput<Vector2>("value", (flow) =>
                        {
                            return lastValue == null ? Vector2.zero : (Vector2)lastValue;
                        });
                        break;

                    case "Euler":
                        value = ValueOutput<Vector3>("value", (flow) =>
                        {
                            return lastValue == null ? Vector3.zero : (Vector3)lastValue;
                        });
                        break;

                    case "Float":
                        value = ValueOutput<float>("value", (flow) =>
                        {
                            return lastValue == null ? 0f : (float)lastValue;
                        });
                        break;

                    case "Integer":
                        value = ValueOutput<int>("value", (flow) =>
                        {
                            return lastValue == null ? 0 : (int)lastValue;
                        });
                        break;

                    case "Quaternion":
                        value = ValueOutput<Quaternion>("value", (flow) =>
                        {
                            return lastValue == null ? new Quaternion(0f, 0f, 0f, 0f) : (Quaternion)lastValue;
                        });
                        break;

                    case "Stick":
                        value = ValueOutput<Vector2>("value", (flow) =>
                        {
                            return lastValue == null ? Vector2.zero : (Vector2)lastValue;
                        });
                        break;

                    case "Touch":
                        value = ValueOutput<TouchState>("value", (flow) =>
                        {
                            return lastValue == null ? (TouchState)typeof(TouchState).Default() : (TouchState)lastValue;
                        });
                        break;

                    case "Vector2":
                        value = ValueOutput<Vector2>("value", (flow) =>
                        {
                            return lastValue == null ? Vector2.zero : (Vector2)lastValue;
                        });
                        break;

                    case "Vector3":
                        value = ValueOutput<Vector3>("value", (flow) =>
                        {
                            return lastValue == null ? Vector3.zero : (Vector3)lastValue;
                        });
                        break;

                    default:
                        value = ValueOutput<object>("value", (flow) =>
                        {
                            return lastValue == null ? action.activeControl?.ReadDefaultValueAsObject() : lastValue;
                        });
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
                base.StartListening(stack);
                action = asset.FindAction(action.name);
                playerInput.StartCoroutine(CheckInput());
            }
#endif
        }

        public IEnumerator CheckInput()
        {
            var hasReleased = false;
            var hasPressedOnce = false;
            isPressing = false;

            while (true)
            {
                if (action != null)
                {
                    var justPerformed = false;
                    if (!isPressing)
                    {
                        if (hasPressedOnce == false || action.activeControl?.ReadValueAsObject() != action.activeControl?.ReadDefaultValueAsObject())
                        {
                            isPressing = true;
                            justPerformed = true;
                            hasReleased = false;
                            hasPressedOnce = true;
                        }
                    }

                    switch (status)
                    {
                        case InputActionStatus.Press:
                            if (justPerformed)
                            {
                                SetLastValue();
                                Trigger();
                            }
                            break;

                        case InputActionStatus.Hold:
                            if (isPressing)
                            {
                                SetLastValue();
                                Trigger();
                            }
                            break;

                        case InputActionStatus.Release:
                            if (!isPressing && !justPerformed && !hasReleased)
                            {
                                SetLastValue();
                                Trigger();
                                hasReleased = true;
                            }
                            break;
                    }

                    if (action.activeControl?.ReadValueAsObject() == action.activeControl?.ReadDefaultValueAsObject())
                    {
                        isPressing = false;
                        SetLastValue();
                    }
                }

                yield return null;
            }
        }

        private void SetLastValue()
        {
            var val = action.ReadValueAsObject();
            if (val == null)
            {
                val = GetDefault();
            }

            lastValue = val;
        }

        private object GetDefault()
        {
            switch (action.expectedControlType)
            {
                case "Axis":
                    return 0f;

                case "Bone":
                    return typeof(UnityEngine.XR.Bone).Default();

                case "Button":
                    return 0f;

                case "Digital":
                    return 0f;

                case "Double":
                    return 0f;

                case "Dpad":
                    return Vector2.zero;

                case "Euler":
                    return Vector3.zero;

                case "Float":
                    return 0f;

                case "Integer":
                    return 0;

                case "Quaternion":
                    return new Quaternion(0f, 0f, 0f, 0f);

                case "Stick":
                    return Vector2.zero;

                case "Touch":
                    return (TouchState)typeof(TouchState).Default();

                case "Vector2":
                    return Vector2.zero;

                case "Vector3":
                    return Vector3.zero;

                default:
                    return null;
            }
        }

        private void Trigger()
        {
            if (coroutine)
            {
                Flow.New(reference).StartCoroutine(trigger);
            }
            else
            {
                Flow.New(reference).Invoke(trigger);
            }
        }

#if ENABLE_INPUT_SYSTEM
        [Obsolete]
        private void Pressed(InputAction.CallbackContext context)
        {
        }

        [Obsolete]
        private IEnumerator Pressing()
        {
            yield break;
        }

        [Obsolete]
        private void Released(InputAction.CallbackContext context)
        {

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
                base.StopListening(stack);

                playerInput.StopCoroutine(CheckInput());
            }
#endif
        }
    }

    /// <summary>
    /// The actions status type. How the action is being used.
    /// </summary>
    public enum InputActionStatus
    {
        Press,
        Hold,
        Release
    }
}