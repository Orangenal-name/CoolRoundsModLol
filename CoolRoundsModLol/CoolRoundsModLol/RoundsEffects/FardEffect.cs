using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ModdingUtils.RoundsEffects;
using UnboundLib;
using UnityEngine;

namespace CoolRoundsModLol.RoundsEffects
{
    class FardEffect : HitSurfaceEffect
    {
        private Player player;
        private bool hasToxic;
        public override void Hit(Vector2 position, Vector2 normal, Vector2 velocity)
        {
            this.player = this.gameObject.GetComponent<Player>();

            foreach (CardInfo info in player.data.currentCards)
            {
                if (info.cardName.ToLower() == "toxic cloud")
                {
                    hasToxic = true;
                    break;
                }
            }
            AudioSource audioSource = gameObject.GetOrAddComponent<AudioSource>();
            if (hasToxic)
            {
                audioSource.PlayOneShot(Assets.fardList[0], 6.0f);
            }
            audioSource.PlayOneShot(Assets.fardList[0], 3.0f);
        }
    }
}
