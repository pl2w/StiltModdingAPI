﻿using Rekt.Game;
using UnityEngine;

namespace StiltModdingAPI.Behaviours.Powers {
    public class ExamplePower : PowerUp {
        public override PowerUps.PowerUpsEnum PowerUpType => (PowerUps.PowerUpsEnum)50;

        void Update() {
            if(enabled)
                Player.Position += new Vector3(0, 1, 0) * Time.deltaTime;
        }
    }
}