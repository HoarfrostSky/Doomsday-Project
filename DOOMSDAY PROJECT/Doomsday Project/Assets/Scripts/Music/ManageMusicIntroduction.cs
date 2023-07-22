using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Music.Interfaces;

namespace Music
{
    public class ManageMusicIntroduction : AMusicManager
    {
        public AudioClip[] intro1Layers;
        public AudioClip[] intro2Layers;

        public override void StartMusic(int n)
        {
            Debug.Log("Comienza la musica");
            if (n == 1)
            {
                RegisterLayers(intro1Layers);
                currentLayers[0].loop = false;
            }
            else if (n == 2)
            {
                currentLayers[0].volume = 0f;
                
                RegisterLayers(intro2Layers);
            }
            else Debug.LogError("ERROR: NO SE HA INTRODUCIDO EL NÚMERO DE CANCIÓN INTRODUCCIÓN CORRECTO. DEBE SER 1 O 2");
        }

        public bool IsLayerPlaying(int nLayer)
        {
            return currentLayers[nLayer].isPlaying;
        }
    }
}
