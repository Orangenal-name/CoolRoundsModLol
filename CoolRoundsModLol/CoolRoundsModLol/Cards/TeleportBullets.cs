using CoolRoundsModLol.RoundsEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace CoolRoundsModLol.Cards
{
    class TeleportBullets : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            cardInfo.allowMultiple = false;
            #if DEBUG
            UnityEngine.Debug.Log($"[{CoolRoundsModLol.ModInitials}][Card] {GetTitle()} has been setup.");
            #endif
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
            gun.reloadTime *= 0.7f;
            player.gameObject.GetOrAddComponent<TeleportToBulletEffect>();
            #if DEBUG
            UnityEngine.Debug.Log($"[{CoolRoundsModLol.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
            #endif
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
            #if DEBUG
            UnityEngine.Debug.Log($"[{CoolRoundsModLol.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
            #endif
        }

        protected override string GetTitle()
        {
            return "Teleporting Bullets";
        }
        protected override string GetDescription()
        {
            return "Teleport to where your bullets land!";
        }
        protected override GameObject GetCardArt()
        {
            return Assets.TPBulletsArt;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Uncommon;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Reload Time",
                    amount = "+30%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.ColdBlue;
        }
        public override string GetModName()
        {
            return CoolRoundsModLol.ModInitials;
        }
    }
}
