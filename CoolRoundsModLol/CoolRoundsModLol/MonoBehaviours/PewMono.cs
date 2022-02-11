using CoolRoundsModLol.Cards;
using System;
using System.Collections.Generic;
using System.Text;
using UnboundLib;
using UnityEngine;

namespace CoolRoundsModLol.MonoBehaviours
{
    class PewMono : MonoBehaviour
    {
        private void Start()
        {
            PlayPew.Play();
        }
    }
    class PlayPew
    {
        public static void Play()
        {
            AudioSource.PlayClipAtPoint(Assets.PewClip, new Vector3(0, 0, 0));
        }
    }
}
