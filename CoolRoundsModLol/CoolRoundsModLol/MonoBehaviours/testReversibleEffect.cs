using ModdingUtils.MonoBehaviours;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoolRoundsModLol.MonoBehaviours
{
    class testReversibleEffect : ReversibleEffect
    {
        float duration = 5f;
        public override void OnStart()
        {
            gunStatModifier.damage_mult = 2;
            ApplyModifiers();
        }
        public override void OnUpdate()
        {
            if (!(duration <= 0))
            {
                duration -= TimeHandler.deltaTime;
            }
            else
            {
                ClearModifiers();
            }
        }
    }
}
