using MelonLoader;
using StiltModdingAPI;

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
    }
}
