using MelonLoader;
using StiltModdingAPI;
using StiltModdingAPI.Behaviours.Powers;
using StiltModdingAPI.Powers;
using UnityEngine;

[assembly: MelonInfo(typeof(Plugin), "StiltModdingAPI", "1.0.0", "pl2w")]
[assembly: MelonGame("Rekt Games", "Stilt")]

namespace StiltModdingAPI
{
    public class Plugin : MelonMod
    {
        public override void OnLateInitializeMelon()
        {
            base.OnLateInitializeMelon();
            Utils.StiltModObject.AddComponent<Inputs>();
        }

        public override void OnGUI()
        {
            base.OnGUI();
            if (GUI.Button(new Rect(5, 5, 250, 25), "give"))
                PowerUpHandler.RegisterPowerUp(typeof(ExamplePower));
        }
    }
}
