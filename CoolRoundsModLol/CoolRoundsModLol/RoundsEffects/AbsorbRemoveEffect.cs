using System;
using System.Collections.Generic;
using System.Text;
using CoolRoundsModLol.Cards;
using ModdingUtils.RoundsEffects;
using UnityEngine;

namespace CoolRoundsModLol.RoundsEffects
{
    class AbsorbRemoveEffect : HitSurfaceEffect
    {
        private Player player;
        private Gun gun;
        private GunAmmo gunAmmo;

        public override void Hit(Vector2 position, Vector2 normal, Vector2 velocity)
        {
            this.player = this.gameObject.GetComponent<Player>();
            this.gun = this.player.GetComponent<Holding>().holdable.GetComponent<Gun>();
            this.gunAmmo = gun.GetComponentInChildren<GunAmmo>();

            if (AbsorbEffect.hasExtraBullets)
            {
                gunAmmo.maxAmmo -= 1;
                AbsorbEffect.extraAmount -= 1;
            }
            if (AbsorbEffect.extraAmount <= 0 && AbsorbEffect.hasExtraBullets)
            {
                AbsorbEffect.hasExtraBullets = false;
                AbsorbEffect.extraAmount = 0;
            }
        }
    }
}
