using ModdingUtils.RoundsEffects;
using UnboundLib;
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

            Vector3 offset = new Vector2(normal.x * player.transform.localScale.x, normal.y * player.transform.localScale.y);
            this.TpLoc = new Vector3(position.x + offset.x, position.y + offset.y, player.transform.position.z);

            player.GetComponentInParent<PlayerCollision>().IgnoreWallForFrames(2);
            player.transform.position = TpLoc;
        }
    }
}
