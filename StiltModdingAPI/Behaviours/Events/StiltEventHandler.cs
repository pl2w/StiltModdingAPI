using MelonLoader;
using UnityEngine;

namespace StiltModdingAPI.Behaviours.Events {
    public class StiltEventHandler : MonoBehaviour {
        public delegate void SceneLoaded(bool ContainsPlayerPrefab, bool IsMultiplayerScene);
        /// <summary>
        /// Gets called a new scene of stilt loads, use this instead of the normal unity scene loaded event.
        /// </summary>
        public static event SceneLoaded OnSceneLoaded;

        public static void CallEvent(int EventID, object[] Data) {
            if (Data == null) return;

            switch (EventID) {
                case 0:
                    if(OnSceneLoaded != null)
                        OnSceneLoaded.Invoke((bool)Data[0], (bool)Data[1]);
                    break;
            }
        }
    }
}