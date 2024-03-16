using StiltModdingAPI.Behaviours.Events;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

namespace StiltModdingAPI {
    public class Inputs : MonoBehaviour {
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

        public static XRController leftController;
        public static XRController rightController;

        void Awake() =>
            StiltEventHandler.OnSceneLoaded += SceneLoaded;

        private void SceneLoaded(bool ContainsPlayerPrefab, bool IsMultiplayerScene) {
            if (!ContainsPlayerPrefab) return;
            leftController = GameObject.Find("Core/PlayerPrefab/Camera Offset/LeftController").AddComponent<XRController>();
            rightController = GameObject.Find("Core/PlayerPrefab/Camera Offset/RightController").AddComponent<XRController>();
            GameObject.Find("Core/PlayerPrefab/Camera Offset/LeftController").GetComponent<XRController>().controllerNode = XRNode.LeftHand;
            GameObject.Find("Core/PlayerPrefab/Camera Offset/RightController").GetComponent<XRController>().controllerNode = XRNode.RightHand;
            //I had to do this because the old system didn't work
        }

        void Update() {
            leftController.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out LeftPrimaryButtonDown);
            leftController.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out LeftSecondaryButtonDown);
            leftController.inputDevice.TryGetFeatureValue(CommonUsages.grip, out LeftGripFloat);
            leftController.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out LeftTriggerFloat);
            leftController.inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out LeftGripDown);
            leftController.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out LeftTriggerDown);
            leftController.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out LeftThumbstick);
            leftController.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out LeftThumbstickDown);

            rightController.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out RightPrimaryButtonDown);
            rightController.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out RightSecondaryButtonDown);
            rightController.inputDevice.TryGetFeatureValue(CommonUsages.grip, out RightGripFloat);
            rightController.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out RightTriggerFloat);
            rightController.inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out RightGripDown);
            rightController.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out RightTriggerDown);
            rightController.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out RightThumbstick);
            rightController.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out RightThumbstickDown);
        }

        public static InputDevice GetControllerDevice(XRNode node) {
            List<InputDevice> list = new List<InputDevice>();
            InputDevices.GetDevicesAtXRNode(node, list);

            if (list.Count > 0)
                return list[0];

            return default;
        }
    }
}
