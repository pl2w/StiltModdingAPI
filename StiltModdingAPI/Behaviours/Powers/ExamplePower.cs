using Rekt.Game;
using StiltModdingAPI.Powers;
using System;
using UnityEngine;

namespace StiltModdingAPI.Behaviours.Powers
{
    public class ExamplePower : PowerUp
    {
        public override PowerUps.PowerUpsEnum PowerUpType => (PowerUps.PowerUpsEnum)PowerUpHandler.GetValidPowerUpIndex();

        void Update()
        {
            if (enabled)
                Player.transform.Rotate(Vector3.up, 1 * Time.deltaTime);
        }
    }
}
