using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ModdingUtils.RoundsEffects;
using UnboundLib;
using UnityEngine;

namespace CoolRoundsModLol
{
    class FardEffect : HitSurfaceEffect
    {
        public override void Hit(Vector2 position, Vector2 normal, Vector2 velocity)
        {
            AudioSource audioSource = gameObject.GetOrAddComponent<AudioSource>();
            audioSource.PlayOneShot(Assets.fardList[0], 5.0f);
        }
    }
}
