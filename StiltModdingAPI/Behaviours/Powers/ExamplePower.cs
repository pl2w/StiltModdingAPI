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
            if(enabled)
                Player.Position += new Vector3(0, 1, 0) * Time.deltaTime;
        }
    }
}
