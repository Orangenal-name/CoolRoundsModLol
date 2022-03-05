using Sonigon;
using Sonigon.Internal;
using UnityEngine;

namespace CoolRoundsModLol.MonoBehaviours
{
    internal class PewMono : MonoBehaviour
    {
        private SoundParameterIntensity soundParameterIntensity = new SoundParameterIntensity(0f, UpdateMode.Continuous);
        public void Start()
        {
            soundParameterIntensity.intensity = 0.5f;
            SoundContainer soundContainer = ScriptableObject.CreateInstance<SoundContainer>();
            soundContainer.setting.volumeIntensityEnable = true;
            soundContainer.audioClip[0] = Assets.PewClip;
            SoundEvent pewSound = ScriptableObject.CreateInstance<SoundEvent>();
            pewSound.soundContainerArray[0] = soundContainer;
            soundParameterIntensity.intensity *= CoolRoundsModLol.globalVolMute.Value;
            SoundManager.Instance.Play(pewSound, base.transform, new SoundParameterBase[]
            {
                soundParameterIntensity
            });
        }
    }
}
