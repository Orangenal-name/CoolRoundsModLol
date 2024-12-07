using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using CoolRoundsModLol.Cards;
using HarmonyLib;
using UnityEngine;
using BepInEx.Configuration;
using UnboundLib.Utils.UI;

namespace CoolRoundsModLol
{
    
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.gununblockablepatch", BepInDependency.DependencyFlags.HardDependency)]
    
    [BepInPlugin(ModId, ModName, Version)]
    
    [BepInProcess("Rounds.exe")]
    public class CoolRoundsModLol : BaseUnityPlugin
    {
        public static CoolRoundsModLol instance { get; private set; }
        private const string ModId = "com.Cool.Rounds.Mod.lol";
        private const string ModName = "CoolRoundsModLol";
        public const string Version = "1.0.0";
        public const string ModInitials = "CRML";

        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
            globalVolMute = base.Config.Bind<float>("CRML", "CRML sounds volume", 100f, "CRML sounds volume");
        }

        public static ConfigEntry<float> globalVolMute;

        private void GlobalVolAction(float val)
        {
            globalVolMute.Value = val;
        }

        private void NewGUI(GameObject menu)
        {
            MenuHandler.CreateSlider("volume for CRML cards", menu, 50, 0, 100, globalVolMute.Value, GlobalVolAction, out UnityEngine.UI.Slider volumeSlider, true);
        }

        void Start()
        {
            instance = this;

            Unbound.RegisterCredits(ModName, new string[] { "Orangenal Name - Developer", "GoldenGaming25 - Idea man" }, new string[] { "GitHub", "Patreon" }, new string[] { "https://github.com/Orangenal-name/CoolRoundsModLol", "https://www.patreon.com/orangenal" });

            #if DEBUG
            CustomCard.BuildCard<TestCard>();
#endif
            Unbound.RegisterMenu("Cool rounds mod lol", () => { }, NewGUI, null, true);
            CustomCard.BuildCard<Fard>();
            CustomCard.BuildCard<Bundle>();
            CustomCard.BuildCard<Piercing>();
            CustomCard.BuildCard<GhostBullet>();
            CustomCard.BuildCard<KnockBackStick>();
            CustomCard.BuildCard<UnoReverse>();
            CustomCard.BuildCard<TeleportBullets>();
            CustomCard.BuildCard<BlockLag>();
            CustomCard.BuildCard<Absorption>();
            CustomCard.BuildCard<PewPewCard>();
            CustomCard.BuildCard<BananaPeel>();
        }
    }
}
