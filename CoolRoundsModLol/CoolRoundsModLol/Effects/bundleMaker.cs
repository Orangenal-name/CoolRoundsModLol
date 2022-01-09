using System;
using System.Collections.Generic;
using System.Text;
using ModdingUtils.RoundsEffects;
using UnityEngine;

namespace CoolRoundsModLol
{
    class bundleMaker : HitSurfaceEffect
    {
        private Player player;
        private Gun gun;
        private GunAmmo gunAmmo;

        public override void Hit(Vector2 position, Vector2 normal, Vector2 velocity)
        {
            this.player = this.gameObject.GetComponent<Player>();
            this.gun = this.player.GetComponent<Holding>().holdable.GetComponent<Gun>();
            this.gunAmmo = gun.GetComponentInChildren<GunAmmo>();

            gun.damage *= gunAmmo.maxAmmo;
            gun.numberOfProjectiles = 1;
            gunAmmo.maxAmmo = 1;
            gun.spread = 0f;
            gun.bursts = 0;
        }
    }
}
