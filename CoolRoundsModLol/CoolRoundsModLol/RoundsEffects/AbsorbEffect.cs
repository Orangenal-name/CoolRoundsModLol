using System;
using System.Collections.Generic;
using System.Text;
using CoolRoundsModLol.Cards;
using ModdingUtils.RoundsEffects;
using UnityEngine;

namespace CoolRoundsModLol
{
    class AbsorbEffect : WasHitEffect
    {
        private Player player;
        private Gun gun;
        private GunAmmo gunAmmo;
        public static bool hasExtraBullets;
        public static int extraAmount;

        public override void WasDealtDamage(Vector2 damage, bool selfDamage)
        {
            this.player = this.gameObject.GetComponent<Player>();
            this.gun = this.player.GetComponent<Holding>().holdable.GetComponent<Gun>();
            this.gunAmmo = gun.GetComponentInChildren<GunAmmo>();

            gunAmmo.maxAmmo += 1;
            hasExtraBullets = true;
            extraAmount += 1;
        }
    }
}
