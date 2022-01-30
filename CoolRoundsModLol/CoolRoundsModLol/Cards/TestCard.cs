using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using ModdingUtils.RoundsEffects;
using CoolRoundsModLol.MonoBehaviours;
using System.Collections.ObjectModel;
using UnboundLib.Utils;
using System.Reflection;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace CoolRoundsModLol.Cards
{
    class TestCard : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            block.forceToAdd = -10f;
            statModifiers.health = 2f;
            block.cdAdd = -9999f;



#if DEBUG
            UnityEngine.Debug.Log($"[{CoolRoundsModLol.ModInitials}][Card] {GetTitle()} has been setup.");
#endif
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
            //player.gameObject.GetOrAddComponent<TestHitSurfaceEffect>();
            gun.unblockable = true;
            TestPlayerMono testMono = player.gameObject.AddComponent<TestPlayerMono>();

            GameObject thruster = (GameObject)Resources.Load("0 cards/Thruster");
            Gun clonedThrusterGun = Instantiate(thruster.GetComponent<Gun>());
            ObjectsToSpawn clonedThrusterObj = clonedThrusterGun.objectsToSpawn[0];
            clonedThrusterObj.AddToProjectile.GetComponent<Thruster>().force = -20000f;

            gun.objectsToSpawn = new[]
            {
                clonedThrusterGun.objectsToSpawn[0]
            };

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
            return "Test card";
        }
        protected override string GetDescription()
        {
            return "Test Card";
        }
        protected override GameObject GetCardArt()
        {
            return Assets.TestArt;
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
                    positive = true,
                    stat = "Health",
                    amount = "×2",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Block Cooldown",
                    amount = "-0.5s",
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
    class CopyThrusters : ICloneable
    {
        public object Clone()
        {
            var variable = (ObjectsToSpawn)MemberwiseClone();
            return variable;
        }
    }
}
