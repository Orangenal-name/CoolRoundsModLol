using CoolRoundsModLol.RoundsEffects;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace CoolRoundsModLol.MonoBehaviours
{
    internal class AbsorbMono : MonoBehaviour
    {
        public void Start()
        {
            
            if (AbsorbEffect.extraBullets > 0)
            {
                AbsorbEffect.reversibleEffect.gunAmmo.maxAmmo -= 1;
                AbsorbEffect.extraBullets -= 1;
            }
        }
    }
}
