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
    class Piercing : CustomCard
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
            gun.unblockable = true;
            gunAmmo.maxAmmo -= 2;
            gun.damage /= 4;
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
            return "Piercing";
        }
        protected override string GetDescription()
        {
            return "Make people unable to block your shots!";
        }
        protected override GameObject GetCardArt()
        {
            return Assets.PiercingArt;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Rare;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Ammo",
                    amount = "-2",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Damage",
                    amount = "-75%",
                    simepleAmount = CardInfoStat.SimpleAmount.aLotLower
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
