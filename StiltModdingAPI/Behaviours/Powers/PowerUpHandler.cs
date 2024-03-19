using HarmonyLib;
using Rekt.Game;
using Rekt.Refs;
using System;
using System.Collections.Generic;
using UnityEngine;
using static Rekt.Game.PowerUps;

namespace StiltModdingAPI.Powers {
    public static class PowerUpHandler {
        public static void RegisterPowerUp(Type powerUp, string powerUpName, Sprite powerUpicon) {
            PowerUp power = (PowerUp)Activator.CreateInstance(powerUp);
            Traverse powerUpsTraverse = Traverse.Create(typeof(PowerUps));
            Dictionary<PowerUpsEnum, int> lookUpTable = powerUpsTraverse.Field("m_indexLookUp").GetValue<Dictionary<PowerUpsEnum, int>>();

            if (lookUpTable.ContainsKey(power.PowerUpType))
                return;

            GameObject powerUpPrefab = new GameObject(powerUpName);
            powerUpPrefab.SetActive(false);
            powerUpPrefab.AddComponent(powerUp);

            PowerUpInfo info = new PowerUpInfo();
            info.m_powerUpType = power.PowerUpType;
            info.m_powerUpStiltPrefab = powerUpPrefab;
            info.m_powerUpIcon = powerUpicon;

            lookUpTable.Add(power.PowerUpType, lookUpTable.Count);
            powerUpsTraverse.Field("m_indexLookUp").SetValue(lookUpTable);

            RefsCollection collection = powerUpsTraverse.Field("Collection").GetValue<RefsCollection>();

            if (collection == null) {
                powerUpsTraverse.Field("m_collection").SetValue(Resources.Load<RefsCollection>("PowerUps"));
                collection = Resources.Load<RefsCollection>("PowerUps");
            }

            collection.m_collection.Add(new RefsCollection.CollectionRef() {
                m_enumId = (int)power.PowerUpType,
                m_name = powerUpName,
                m_referencedObject = power
            });

            powerUpsTraverse.Field("m_collection").SetValue(collection);
        }

        public static void GivePowerUp(PowerUpInfo info, StiltHand hand) =>
            PlayerController.Instance.m_powerUpController.GivePowerUp(info, hand);
    }
}
