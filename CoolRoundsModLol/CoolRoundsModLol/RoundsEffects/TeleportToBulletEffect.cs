using System;
using System.Collections.Generic;
using System.Text;
using ModdingUtils.RoundsEffects;
using UnityEngine;

namespace CoolRoundsModLol.RoundsEffects
{
    class TeleportToBulletEffect : HitSurfaceEffect
    {
        private Player player;
        private Vector3 TpLoc;

        public override void Hit(Vector2 position, Vector2 normal, Vector2 velocity)
        {

            this.player = this.gameObject.GetComponent<Player>();
            this.TpLoc = new Vector3(position.x + player.transform.localScale.x, position.y + player.transform.localScale.y, player.transform.position.z);

            player.GetComponentInParent<PlayerCollision>().IgnoreWallForFrames(2);
            player.transform.position = TpLoc;
        }
    }
}
