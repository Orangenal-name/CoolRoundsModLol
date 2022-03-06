using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ModdingUtils.RoundsEffects;
using Sonigon;
using Sonigon.Internal;
using UnboundLib;
using UnityEngine;

namespace CoolRoundsModLol.RoundsEffects
{
    class FardEffect : HitSurfaceEffect
    {
        private Player player;
        private SoundParameterIntensity soundParameterIntensity = new SoundParameterIntensity(0f, UpdateMode.Continuous);
        System.Random random = new System.Random();
        public override void Hit(Vector2 position, Vector2 normal, Vector2 velocity)
        {
            this.player = this.gameObject.GetComponent<Player>();
            soundParameterIntensity.intensity = 0.5f;
            foreach (CardInfo info in player.data.currentCards)
            {
                if (info.cardName.ToLower() == "toxic cloud")
                {
                    soundParameterIntensity.intensity = 1f;
                    break;
                }
            }

            SoundContainer soundContainer = ScriptableObject.CreateInstance<SoundContainer>();
            soundContainer.setting.volumeIntensityEnable = true;
            float percentChance = 0.25f;
            if (UnityEngine.Random.value <= percentChance)
            {
                soundContainer.audioClip[0] = Assets.RareFardClip;
            }
            else
            {
                soundContainer.audioClip[0] = Assets.FardClip;
            }

            SoundEvent fardSound = ScriptableObject.CreateInstance<SoundEvent>();
            fardSound.soundContainerArray[0] = soundContainer;
            soundParameterIntensity.intensity *= CoolRoundsModLol.globalVolMute.Value;
            SoundManager.Instance.Play(fardSound, base.transform, new SoundParameterBase[]
            {
                soundParameterIntensity
            });
        }
    }
}
