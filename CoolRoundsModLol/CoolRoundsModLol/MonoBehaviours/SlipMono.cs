using ModdingUtils.MonoBehaviours;
using System.Threading.Tasks;
using UnityEngine;

namespace CoolRoundsModLol.MonoBehaviours
{
    class SlipMono : ReversibleEffect
    {
        float time = Time.time;
        float lastSlipped = Time.fixedTime;
        int waitTime = 0;
        public override void OnStart()
        {
            waitTime = Random.Range(10,100);
        }
        public override void OnUpdate()
        {
            if (time - lastSlipped >= waitTime)
            {
                characterStatModifiersModifier.movementSpeed_mult += 0.2f;
            }
            Debug.Log(Time.time);
        }
    }
}
