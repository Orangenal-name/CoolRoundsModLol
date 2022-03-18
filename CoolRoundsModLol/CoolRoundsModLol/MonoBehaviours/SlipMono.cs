using ModdingUtils.MonoBehaviours;
using System.Threading.Tasks;
using UnityEngine;

namespace CoolRoundsModLol.MonoBehaviours
{
    class SlipMono : ReversibleEffect
    {
        private float remaining = 0;
        private bool WillSlip = false;
        private float rand = 0;
        
        public override void OnStart()
        {
            characterStatModifiersModifier.movementSpeed_mult = 10f;
        }
        public override void OnUpdate()
        {
            rand = UnityEngine.Random.value;
            float percentChance = 0.005f;
            if (rand <= percentChance)
            {
                WillSlip = true;
            }

            if (remaining <= 0 && WillSlip)
            {
                ApplyModifiers();
                remaining = 0.05f;
                WillSlip = false;
            }
            
            if (remaining <= 0)
            {
                ClearModifiers();
            }
            else
            {
                remaining -= TimeHandler.deltaTime;
            }
        }
    }
}
