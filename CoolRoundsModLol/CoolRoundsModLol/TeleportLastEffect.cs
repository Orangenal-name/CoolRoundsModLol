using System;
using System.Collections.Generic;
using System.Text;
using ModdingUtils.RoundsEffects;
using UnityEngine;

namespace CoolRoundsModLol
{
    class TeleportLastEffect : HitSurfaceEffect
    {
        private Player player;
        private Gun gun;
        private GunAmmo gunAmmo;
        private Vector3 TpLoc;

        public override void Hit(Vector2 position, Vector2 normal, Vector2 velocity)
        {

            this.player = this.gameObject.GetComponent<Player>();
            this.gun = this.player.GetComponent<Holding>().holdable.GetComponent<Gun>();
            this.gunAmmo = gun.GetComponentInChildren<GunAmmo>();
            this.TpLoc = new Vector3(position.x, position.y, player.transform.position.z);

            if (gun.isReloading)
            {
                player.transform.position = TpLoc;
            }
        }
    }
}
