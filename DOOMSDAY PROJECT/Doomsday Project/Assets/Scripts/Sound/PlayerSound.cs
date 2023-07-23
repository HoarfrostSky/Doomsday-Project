using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sounds
{
    public class PlayerSound : MonoBehaviour
    {

        public AudioClip[] audioClips;
        private AudioSource audios;
        private AudioSource audioSourcePasos;

        private void Awake()
        {
            audios = this.gameObject.AddComponent<AudioSource>();
            audios.playOnAwake = false;
            audios.reverbZoneMix = 0f;

            audioSourcePasos = this.gameObject.AddComponent<AudioSource>();
            audioSourcePasos.playOnAwake = false;
            audioSourcePasos.volume = 0f;
            audioSourcePasos.loop = true;
            audioSourcePasos.clip = audioClips[3];
            audioSourcePasos.Play();
        }

        public void PlayAttackSound()
        {
            audios.clip = audioClips[0];
            audios.Play();
        }

        public void PlayAbrirPausa()
        {
            audios.clip = audioClips[1];
            audios.Play();
        }

        public void PlayCerrarPausa()
        {
            audios.clip = audioClips[2];
            audios.Play();
        }

        public void PlaySoundPasos()
        {
            audioSourcePasos.volume = 0.25f;
        }

        public void StopSoundPasos()
        {
            audioSourcePasos.volume = 0f;
        }
    }
}
