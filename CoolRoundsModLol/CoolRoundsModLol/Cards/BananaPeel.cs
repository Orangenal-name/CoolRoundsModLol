using CoolRoundsModLol.MonoBehaviours;
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
    class BananaPeel : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            #if DEBUG
            UnityEngine.Debug.Log($"[{CoolRoundsModLol.ModInitials}][Card] {GetTitle()} has been setup.");
            #endif
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
            SlipMono slipMono = player.gameObject.AddComponent<SlipMono>();
            slipMono.player = player;
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
            return "Banana Peels";
        }
        protected override string GetDescription()
        {
            return "Randomly slip around";
        }
        protected override GameObject GetCardArt()
        {
            return Assets.PeelsArt;
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
                    positive = true,
                    stat = "Speed when slipping",
                    amount = "+20%",
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
