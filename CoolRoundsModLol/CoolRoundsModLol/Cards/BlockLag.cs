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
    class BlockLag : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            cardInfo.allowMultiple = false;
            block.cdAdd = 0.25f;
            #if DEBUG
            UnityEngine.Debug.Log($"[{CoolRoundsModLol.ModInitials}][Card] {GetTitle()} has been setup.");
            #endif
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
            LagEffect Rewind = player.gameObject.GetOrAddComponent<LagEffect>();
            Rewind.player = player;
            Rewind.block = block;
            Rewind.data = data;
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
            return "Rubber Banding";
        }
        protected override string GetDescription()
        {
            return "When you block, 5 seconds later you lag back to where you were when you blocked!";
        }
        protected override GameObject GetCardArt()
        {
            return Assets.RubberBandArt;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Block Cooldown",
                    amount = "+0.25s",
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
