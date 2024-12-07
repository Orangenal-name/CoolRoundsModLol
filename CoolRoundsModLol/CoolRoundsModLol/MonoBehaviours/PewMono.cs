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
            soundParameterIntensity.intensity = 1f;
            SoundContainer soundContainer = ScriptableObject.CreateInstance<SoundContainer>();
            soundContainer.setting.volumeIntensityEnable = true;
            soundContainer.audioClip[0] = Assets.PewClip;
            SoundEvent pewSound = ScriptableObject.CreateInstance<SoundEvent>();
            pewSound.soundContainerArray[0] = soundContainer;
            soundParameterIntensity.intensity *= CoolRoundsModLol.globalVolMute.Value/100;
            SoundManager.Instance.Play(pewSound, base.transform, new SoundParameterBase[]
            {
                soundParameterIntensity
            });
        }
    }
}
