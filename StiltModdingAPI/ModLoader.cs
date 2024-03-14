using MelonLoader;
using StiltModdingAPI;
using StiltModdingAPI.Behaviours.Events;
using UnityEngine;

[assembly: MelonInfo(typeof(ModLoader), "StiltModdingAPI", "1.0.0", "pl2w & MrBanana")]
[assembly: MelonGame("Rekt Games", "Stilt")]
namespace StiltModdingAPI {
    public class ModLoader : MelonMod {
        public static ModLoader instance;
        public GameObject APIManager;

        public override void OnLateInitializeMelon() {
            base.OnLateInitializeMelon();

            instance = this;
            CreateManagerForObject();
        }

        void CreateManagerForObject() {
            APIManager = new GameObject("StiltModdingAPIManager");
            APIManager.AddComponent<StiltEventHandler>();
            APIManager.AddComponent<Inputs>();
            GameObject.DontDestroyOnLoad(APIManager);
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName) {
            base.OnSceneWasLoaded(buildIndex, sceneName);
            GameObject[] allObjs = Resources.FindObjectsOfTypeAll<GameObject>();
            bool first = false;
            bool second = false;
            foreach (GameObject obj in allObjs) {
                if (obj.name == "PlayerPrefab" || obj.name == "PlayerPrefab(clone)")
                    first = true;

                if (obj.name == "NetworkTime")
                    second = true;
            }

            StiltEventHandler.CallEvent(1, new object[] { first, second });
        }
    }
}
