using HarmonyLib;
using Rekt.Game;
using Rekt.Refs;
using StiltModdingAPI.Behaviours.Powers;
using System.Collections.Generic;

namespace StiltModdingAPI.Powers
{
    public static class PowerUpHandler
    {
        public static Dictionary<PowerUps.PowerUpsEnum, int> powerUpLookUp = new Dictionary<PowerUps.PowerUpsEnum, int>()
        {
            {
                PowerUps.PowerUpsEnum.None,
                0
            },
            {
                PowerUps.PowerUpsEnum.HookShoot,
                1
            },
            {
                PowerUps.PowerUpsEnum.HoverGlide,
                2
            },
            {
                PowerUps.PowerUpsEnum.FirePistol,
                3
            },
            {
                PowerUps.PowerUpsEnum.CoinMagnet,
                4
            },
            {
                PowerUps.PowerUpsEnum.RocketBoost,
                5
            },
            {
                PowerUps.PowerUpsEnum.SlowMotion,
                6
            },
            {
                PowerUps.PowerUpsEnum.Flag,
                7
            }
        };

        public static void GiveExample()
        {
            PowerUpInfo info = new PowerUpInfo();
            info.m_powerUpStiltPrefab = new UnityEngine.GameObject("ExamplePower");
            ExamplePower power = info.m_powerUpStiltPrefab.AddComponent<ExamplePower>();
            info.m_powerUpType = power.PowerUpType;

            PlayerController.Instance.m_powerUpController.GivePowerUp(info, StiltHand.Left);
        }

        public static int GetValidPowerUpIndex() => powerUpLookUp.Count;
    }
}
