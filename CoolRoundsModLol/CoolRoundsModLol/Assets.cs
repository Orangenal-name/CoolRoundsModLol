using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CoolRoundsModLol
{

    internal class Assets
    {

        private static readonly AssetBundle Bundle = Jotunn.Utils.AssetUtils.LoadAssetBundleFromResources("coolroundsartlol", typeof(CoolRoundsModLol).Assembly);

        public static GameObject BundleArt = Bundle.LoadAsset<GameObject>("C_BundleCard");
        public static GameObject GhostBulletArt = Bundle.LoadAsset<GameObject>("C_GhostBullet");
        public static GameObject UnoReverseArt = Bundle.LoadAsset<GameObject>("C_UnoReverse");
        public static GameObject FardBulletArt = Bundle.LoadAsset<GameObject>("C_Fard");
        public static GameObject KnockbackArt = Bundle.LoadAsset<GameObject>("C_Knockback");
        public static GameObject TPBulletsArt = Bundle.LoadAsset<GameObject>("C_TPBullets");
        public static GameObject PiercingArt = Bundle.LoadAsset<GameObject>("C_Piercing");
        public static GameObject RubberBandArt = Bundle.LoadAsset<GameObject>("C_Rubber");
        public static GameObject AbsorbArt = Bundle.LoadAsset<GameObject>("C_Absorb");
        public static GameObject TestArt = Bundle.LoadAsset<GameObject>("C_Test");

        public static List<AudioClip> fardList = Bundle.LoadAllAssets<AudioClip>().ToList().Where(clip => clip.name.Contains("Fard")).ToList();
    }
}
