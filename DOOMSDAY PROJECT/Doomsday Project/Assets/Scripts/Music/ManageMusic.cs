using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Souls.Interfaces;

namespace Music
{
    public class ManageMusic : MonoBehaviour
    {
        public AudioSource judgeMusicSource;

        public AudioClip[] HarnLayers;
        public AudioClip[] StrangeLayers;
        public AudioClip[] NurLayers;
        public AudioClip[] BrettaLayers;
        public AudioClip[] HayureLayers;
        public AudioClip[] ColinLayers;
        public AudioClip[] LennaLayers;

        public const int MAX_LAYERS = 5;
        private float currentVolume = 0;

        private AudioSource[] currentLayers =  new AudioSource[MAX_LAYERS];

        public void StartMusic(int n)
        {
            switch(n)
            {
                case 0: //Aleatorio
                    Debug.Log("Se ha elegido musica para aleatorio");
                    
                    break;
                case 1: //Harn
                    Debug.Log("Se ha elegido musica para Harn");
                    RegisterLayers(HarnLayers);
                    

                    break;
                case 2: //Strange
                    Debug.Log("Se ha elegido musica para Strange");
                    RegisterLayers(StrangeLayers);

                    break;
                case 3: //Nur
                    Debug.Log("Se ha elegido musica para Nur");
                    RegisterLayers(NurLayers);

                    break;
                case 4: //Bretta
                    Debug.Log("Se ha elegido musica para Bretta");
                    RegisterLayers(BrettaLayers);

                    break;
                case 5: //Hayure
                    Debug.Log("Se ha elegido musica para Hayure");
                    RegisterLayers(HayureLayers);

                    break;
                case 6: //Colin
                    Debug.Log("Se ha elegido musica para Colin");
                    RegisterLayers(ColinLayers);

                    break;
                case 8: //Lenna
                    Debug.Log("Se ha elegido musica para Lenna");
                    RegisterLayers(LennaLayers);

                    break;

            }
        }

        private void RegisterLayers(AudioClip[] musicLayerClips)
        {
            for(int i = 0; i < musicLayerClips.Length; i++)
            {
                currentLayers[i] = this.gameObject.AddComponent<AudioSource>();
                currentLayers[i].clip = musicLayerClips[i];
                currentLayers[i].volume = 0f;
                currentLayers[i].loop = true;
                currentLayers[i].Play();
            }
        }

        public void ManageVolumeLayer(int nLayer, float iniVol, float endVol, float speedChange)
        {
            StartCoroutine(VolumeLerp(currentLayers[nLayer], iniVol/100, endVol/100, speedChange));
        }

        IEnumerator VolumeLerp(AudioSource musicLayer, float initialVolume, float endVolume, float speed)
        {
            float elapsed = 0;
            while (musicLayer.volume != endVolume)
            {
                currentVolume = Mathf.Lerp(initialVolume, endVolume, elapsed);
                musicLayer.volume = currentVolume;
                elapsed += (0.001f * speed * Time.deltaTime);
                yield return null;
            }
        }

        public void StartJudgeMusic(float startV, float endV)
        {
            for(int i = 0; i < currentLayers.Length; i++)
            {
                StartCoroutine(VolumeLerp(currentLayers[i], 100f, 0f, 300f));
            }

            judgeMusicSource.Play();
            JudgeMusicVolume(startV, endV);
        }

        public void JudgeMusicVolume(float iniV, float endV)
        {
            StartCoroutine(VolumeLerp(judgeMusicSource, iniV, endV, 300f));
        }

        public float GetCurrentVolume()
        {
            return this.currentVolume;
        }
    }
}
