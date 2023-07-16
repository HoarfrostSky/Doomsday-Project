using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Souls.Interfaces;

namespace Music
{
    public class ManageMusic : MonoBehaviour
    {
        public AudioClip[] HarnLayers;
        public AudioClip[] StrangeLayers;
        public AudioClip[] BrettaLayers;

        public const int MAX_LAYERS = 5;

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

                    break;
                case 4: //Bretta
                    Debug.Log("Se ha elegido musica para Bretta");
                    RegisterLayers(BrettaLayers);

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
            Debug.Log("Capa a la que se le cambiará el volumen: " + nLayer);
            Debug.Log("Volumen inicial: " + iniVol/100);
            Debug.Log("Volumen final: " + endVol/100);
            StartCoroutine(VolumeLerp(currentLayers[nLayer], iniVol/100, endVol/100, speedChange));
        }

        IEnumerator VolumeLerp(AudioSource musicLayer, float initialVolume, float endVolume, float speed)
        {
            float elapsed = 0;
            while (musicLayer.volume != endVolume)
            {
                musicLayer.volume = Mathf.Lerp(initialVolume, endVolume, elapsed);
                elapsed += (0.001f * speed * Time.deltaTime);

                Debug.Log("Volumen actual de la capa es " + musicLayer.volume);
                yield return null;
            }
        }
    }
}
