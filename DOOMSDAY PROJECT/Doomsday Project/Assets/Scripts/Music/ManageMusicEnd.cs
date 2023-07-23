using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Music.Interfaces;

namespace Music
{
    public class ManageMusicEnd : AMusicManager
    {
        public AudioClip[] dialogueMusic;
        public AudioClip[] condemnMusic;

        public override void StartMusic(int n)
        {
            if(n == 1)
            {
                RegisterLayers(dialogueMusic);
            }
            else if (n == 2)
            {
                RegisterLayers(condemnMusic);
            }
        }
    }
}
