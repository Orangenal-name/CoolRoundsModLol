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

        public static List<AudioClip> fardList = Bundle.LoadAllAssets<AudioClip>().ToList().Where(clip => clip.name.Contains("Fard")).ToList();
    }
}
