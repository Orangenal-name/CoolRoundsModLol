using Sonigon;
using UnityEngine;

namespace CoolRoundsModLol.MonoBehaviours
{
    internal class PewMono : MonoBehaviour
    {
        public void Start()
        {
            SoundContainer soundContainer = ScriptableObject.CreateInstance<SoundContainer>();
            soundContainer.audioClip[0] = Assets.PewClip;
            SoundEvent pewSound = ScriptableObject.CreateInstance<SoundEvent>();
            pewSound.soundContainerArray[0] = soundContainer;

            SoundManager.Instance.Play(pewSound, base.transform);
        }
    }
}
