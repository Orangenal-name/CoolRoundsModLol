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
            AudioSource audioSource = this.GetComponent<Transform>().GetComponent<GameObject>().GetOrAddComponent<AudioSource>();
            audioSource.PlayOneShot(Assets.PewClip, 3.0f);
        }
    }
}
