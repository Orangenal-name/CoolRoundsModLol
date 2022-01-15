using System;
using System.Collections.Generic;
using System.Text;
using ModdingUtils.RoundsEffects;
using UnityEngine;

namespace CoolRoundsModLol
{
    class TestHitSurfaceEffect : HitSurfaceEffect
    {
        private Player player;
        private Gun gun;

        public override void Hit(Vector2 position, Vector2 normal, Vector2 velocity)
        {

            this.player = this.gameObject.GetComponent<Player>();
            this.gun = this.player.GetComponent<Holding>().holdable.GetComponent<Gun>();
            gun.numberOfProjectiles = 10;
            gun.spread = 0f;
        }
    }
}
