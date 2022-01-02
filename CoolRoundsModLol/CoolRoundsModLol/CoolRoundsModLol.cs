using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using CoolRoundsModLol.Cards;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;

namespace CoolRoundsModLol
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    // Declares our mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class CoolRoundsModLol : BaseUnityPlugin
    {
        public static CoolRoundsModLol instance { get; private set; }
        private const string ModId = "com.Cool.Rounds.Mod.lol";
        private const string ModName = "CoolRoundsModLol";
        public const string Version = "1.0.0"; // What version are we on (major.minor.patch)?
        public const string ModInitials = "CRML";

        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }
        void Start()
        {
            instance = this;
            CustomCard.BuildCard<MyCardName>();
        }
    }
}
