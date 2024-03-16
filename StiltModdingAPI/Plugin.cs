using MelonLoader;
using StiltModdingAPI;
using StiltModdingAPI.Behaviours.Events;
using UnityEngine;

[assembly: MelonInfo(typeof(Plugin), "StiltModdingAPI", "1.0.0", "pl2w")]
[assembly: MelonGame("Rekt Games", "Stilt")]

namespace StiltModdingAPI
{
    public class Plugin : MelonMod
    {
        public static GameObject StiltModObject;

        public override void OnLateInitializeMelon()
        {
            base.OnLateInitializeMelon();

            CreateStiltModObject();
            StiltModObject.AddComponent<Inputs>();
        }

        void CreateStiltModObject()
        {
            StiltModObject = new GameObject("StiltModObject");
            StiltModObject.AddComponent<StiltEventHandler>();
            StiltModObject.AddComponent<Inputs>();
            GameObject.DontDestroyOnLoad(StiltModObject);
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            base.OnSceneWasLoaded(buildIndex, sceneName);
            GameObject[] allObjs = Resources.FindObjectsOfTypeAll<GameObject>();
            bool first = false;
            bool second = false;
            foreach (GameObject obj in allObjs)
            {
                if (obj.name == "PlayerPrefab" || obj.name == "PlayerPrefab(clone)")
                    first = true;

                if (obj.name == "NetworkTime")
                    second = true;
            }

            StiltEventHandler.CallEvent(0, new object[] { first, second });
        }
    }
}
