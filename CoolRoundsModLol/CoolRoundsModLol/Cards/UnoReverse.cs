using CoolRoundsModLol.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace CoolRoundsModLol.Cards
{
    class UnoReverse : CustomCard
    {

        private float block_cooldown = 0.5f;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.allowMultiple = false;
            block.cdMultiplier = 1f + block_cooldown;
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {

            //BehindYou_Effect behindYou = player.gameObject.AddComponent<BehindYou_Effect>();
            SwapEffect behindYou = player.gameObject.GetOrAddComponent<SwapEffect>();
            behindYou.player = player;
            behindYou.block = block;
            behindYou.data = data;
        }
        public override void OnRemoveCard()
        {

        }
        protected override string GetTitle()
        {
            return "Uno Reverse";
        }
        protected override string GetDescription()
        {
            return " Change directions! You swap positions with your enemies when you block!";
        }
        protected override GameObject GetCardArt()
        {
            return Assets.UnoReverseArt;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Rare;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                CardTools.FormatStat(false,"Block Cooldown",block_cooldown)
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.EvilPurple;
        }
        public override string GetModName()
        {
            return CoolRoundsModLol.ModInitials;
        }
    }
}
