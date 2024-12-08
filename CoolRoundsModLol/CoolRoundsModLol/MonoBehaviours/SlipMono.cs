using ModdingUtils.MonoBehaviours;
using System.Threading.Tasks;
using UnityEngine;

namespace CoolRoundsModLol.MonoBehaviours
{
    class SlipMono : MonoBehaviour
    {
        private float remaining = 0;
        private bool WillSlip = false;
        private float rand = 0;
        private Player player;
        private ReversibleEffect reversibleEffect;
        private float percentChance = 0.005f;

        public void Start()
        {
            this.player = this.gameObject.GetComponent<Player>();
            reversibleEffect = player.gameObject.AddComponent<ReversibleEffect>();
            reversibleEffect.player = player;
            reversibleEffect.characterStatModifiersModifier.movementSpeed_mult = 10f;
        }
        public void FixedUpdate()
        {
            this.rand = UnityEngine.Random.value;
            if (rand <= percentChance)
            {
                WillSlip = true;
            }
            if (remaining <= 0 && WillSlip)
            {
                reversibleEffect.ApplyModifiers();
                remaining = 0.05f;
                WillSlip = false;
            }
            if (remaining < 0)
            {
                reversibleEffect.ClearModifiers();
            }
            else
            {
                remaining -= TimeHandler.deltaTime;
            }
        }
    }
}
