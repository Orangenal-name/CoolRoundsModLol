using System;
using System.Collections.Generic;
using System.Text;
using CoolRoundsModLol.Cards;
using ModdingUtils.MonoBehaviours;
using ModdingUtils.RoundsEffects;
using UnityEngine;

namespace CoolRoundsModLol.RoundsEffects
{
    class AbsorbEffect : WasHitEffect
    {
        private Player player;
        private Gun gun;
        private GunAmmo gunAmmo;
        public static ReversibleEffect reversibleEffect;
        public static int extraBullets = 0;

        public override void WasDealtDamage(Vector2 damage, bool selfDamage)
        {
            this.player = this.gameObject.GetComponent<Player>();
            if (player.data.health <= 0)
            {
                reversibleEffect.gunAmmo.maxAmmo -= extraBullets;
                extraBullets = 0;
                return;
            }
            
            if (selfDamage || player.data.lastSourceOfDamage == null) return;

            this.gun = this.player.GetComponent<Holding>().holdable.GetComponent<Gun>();
            this.gunAmmo = gun.GetComponentInChildren<GunAmmo>();
            reversibleEffect = player.gameObject.AddComponent<ReversibleEffect>();

            reversibleEffect.gunAmmo.maxAmmo += 1;
            extraBullets += 1;
        }
    }
}
