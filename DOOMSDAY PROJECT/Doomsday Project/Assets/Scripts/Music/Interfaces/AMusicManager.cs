using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Music.Interfaces
{
    public abstract class AMusicManager : MonoBehaviour
    {
        public AudioSource judgeMusicSource;
        public const int MAX_LAYERS = 5;
        [SerializeField] protected AudioSource[] currentLayers = new AudioSource[MAX_LAYERS];

        protected void RegisterLayers(AudioClip[] musicLayerClips)
        {
            for (int i = 0; i < musicLayerClips.Length; i++)
            {
                currentLayers[i] = this.gameObject.AddComponent<AudioSource>();
                currentLayers[i].clip = musicLayerClips[i];
                currentLayers[i].volume = 0f;
                currentLayers[i].loop = true;
                currentLayers[i].Play();
            }
        }

        protected void ResetLayers()
        {
            for (int i = 0; i < currentLayers.Length; i++)
            {
                Destroy(currentLayers[i]);
            }
        }

        public void ManageVolumeLayer(int nLayer, float iniVol, float endVol, float speedChange)
        {
            StartCoroutine(VolumeLerp(currentLayers[nLayer], iniVol / 100, endVol / 100, speedChange));
        }

        IEnumerator VolumeLerp(AudioSource musicLayer, float initialVolume, float endVolume, float speed)
        {
            float elapsed = 0;
            while (musicLayer.volume != endVolume)
            {
                musicLayer.volume = Mathf.Lerp(initialVolume, endVolume, elapsed);
                elapsed += (0.001f * speed * Time.deltaTime);
                yield return null;
            }
        }
        public void StartJudgeMusic(float startV, float endV)
        {
            for (int i = 0; i < currentLayers.Length; i++)
            {
                if (currentLayers[i] != null)
                {
                    ManageVolumeLayer(i, 100f, 0f, 250f);
                }
            }

            JudgeMusicVolume(startV, endV);
            judgeMusicSource.Play();
        }

        public void JudgeMusicVolume(float iniV, float endV)
        {
            StartCoroutine(VolumeLerp(judgeMusicSource, iniV / 100, endV / 100, 200f));
        }

        public abstract void StartMusic(int n);
    }
}