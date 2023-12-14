using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Music
{
    public class VolumeSettings : MonoBehaviour
    {
        public AudioMixer mixer;
        public Slider slider;
        public string parameterName;

        private float volume;

        private void Start()
        {
            SetMusicVolume();
        }

        public void SetMusicVolume()
        {
            volume = slider.value;
            mixer.SetFloat(parameterName, Mathf.Log10(volume)*20);
        }
    }
}   