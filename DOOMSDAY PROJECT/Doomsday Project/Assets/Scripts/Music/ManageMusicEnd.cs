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

        public AudioSource attackSound;

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

        public void StartCondemnMusic()
        {
            StartMusic(2);
            ManageVolumeLayer(0, 0, 100, 200);
        }

        public void StartSadMusic()
        {
            ManageVolumeLayer(1, 0, 100, 300);
        }

        public void PlayAttackSound()
        {
            attackSound.Play();
        }

    }
}

