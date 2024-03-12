using Rekt.Development;
using StiltModdingAPI.Powers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace StiltModdingAPI
{
    public class Inputs : MonoBehaviour 
    {
        public static bool LeftGripDown = false;
        public static bool RightGripDown = false;
        public static bool LeftTriggerDown = false;
        public static bool RightTriggerDown = false;

        public static float LeftGripFloat = 0.0f;
        public static float RightGripFloat = 0.0f;
        public static float LeftTriggerFloat = 0.0f;
        public static float RightTriggerFloat = 0.0f;

        public static bool LeftPrimaryButtonDown = false;
        public static bool RightPrimaryButtonDown = false;
        public static bool LeftSecondaryButtonDown = false;
        public static bool RightSecondaryButtonDown = false;

        public static bool LeftThumbstickDown = false;
        public static bool RightThumbstickDown = false;

        public static Vector2 LeftThumbstick = Vector2.zero;
        public static Vector2 RightThumbstick = Vector2.zero;

        public static InputDevice leftController;
        public static InputDevice rightController;

        void Start()
        {
            leftController = GetControllerDevice(XRNode.LeftHand);
            rightController = GetControllerDevice(XRNode.RightHand);
        }

        void Update()
        {
            leftController.TryGetFeatureValue(CommonUsages.primaryButton, out LeftPrimaryButtonDown);
            leftController.TryGetFeatureValue(CommonUsages.secondaryButton, out LeftSecondaryButtonDown);
            leftController.TryGetFeatureValue(CommonUsages.grip, out LeftGripFloat);
            leftController.TryGetFeatureValue(CommonUsages.trigger, out LeftTriggerFloat);
            leftController.TryGetFeatureValue(CommonUsages.gripButton, out LeftGripDown);
            leftController.TryGetFeatureValue(CommonUsages.triggerButton, out LeftTriggerDown);
            leftController.TryGetFeatureValue(CommonUsages.primary2DAxis, out LeftThumbstick);
            leftController.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out LeftThumbstickDown);

            rightController.TryGetFeatureValue(CommonUsages.primaryButton, out RightPrimaryButtonDown);
            rightController.TryGetFeatureValue(CommonUsages.secondaryButton, out RightSecondaryButtonDown);
            rightController.TryGetFeatureValue(CommonUsages.grip, out RightGripFloat);
            rightController.TryGetFeatureValue(CommonUsages.trigger, out RightTriggerFloat);
            rightController.TryGetFeatureValue(CommonUsages.gripButton, out RightGripDown);
            rightController.TryGetFeatureValue(CommonUsages.triggerButton, out RightTriggerDown);
            rightController.TryGetFeatureValue(CommonUsages.primary2DAxis, out RightThumbstick);
            rightController.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out RightThumbstickDown);
        }

        public static InputDevice GetControllerDevice(XRNode node)
        {
            List<InputDevice> list = new List<InputDevice>();
            InputDevices.GetDevicesAtXRNode(node, list);

            if (list.Count > 0)
                return list[0];

            return default;
        }
    }
}
