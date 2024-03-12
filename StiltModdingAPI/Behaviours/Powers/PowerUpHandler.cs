using Harmony;
using HarmonyLib;
using MelonLoader;
using Rekt.Game;
using Rekt.Refs;
using System;
using System.Collections.Generic;
using UnityEngine;
using static Rekt.Game.PowerUps;

namespace StiltModdingAPI.Powers
{
    public static class PowerUpHandler
    {
        public static void RegisterPowerUp(Type powerUp)
        {
            PowerUp power = (PowerUp)Activator.CreateInstance(powerUp);

            GameObject powerUpPrefab = new GameObject("ExamplePower");
            powerUpPrefab.SetActive(false);
            powerUpPrefab.AddComponent(powerUp);

            PowerUpInfo info = new PowerUpInfo();
            info.m_powerUpType = power.PowerUpType;
            info.m_powerUpStiltPrefab = powerUpPrefab;

            Traverse powerUpsTraverse = Traverse.Create(typeof(PowerUps));
            Dictionary<PowerUpsEnum, int> lookUpTable = powerUpsTraverse.Field("m_indexLookUp").GetValue<Dictionary<PowerUpsEnum, int>>();
            lookUpTable.Add(power.PowerUpType, lookUpTable.Count);
            powerUpsTraverse.Field("m_indexLookUp").SetValue(lookUpTable);

            RefsCollection collection = powerUpsTraverse.Field("Collection").GetValue<RefsCollection>();

            if(collection == null)
            {
                powerUpsTraverse.Field("m_collection").SetValue(Resources.Load<RefsCollection>("PowerUps"));
                collection = Resources.Load<RefsCollection>("PowerUps");
            }

            collection.m_collection.Add(new RefsCollection.CollectionRef()
            {
                m_enumId = (int)power.PowerUpType,
                m_name = "ExamplePower",
                m_referencedObject = power
            });

            powerUpsTraverse.Field("m_collection").SetValue(collection);

            GivePowerUp(info, StiltHand.Left);
        }

        public static void GivePowerUp(PowerUpInfo info, StiltHand hand)
        {
            PlayerController.Instance.m_powerUpController.GivePowerUp(info, hand);
        }

        public static int GetValidPowerUpIndex() => 50;
    }
}
