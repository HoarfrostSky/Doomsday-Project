using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Souls;

namespace Cinematic
{
    public class ManageCinema : MonoBehaviour
    {
        private int mode = 0;
        private int n = -1;
        private GameObject soul;
        private AnimatorStateInfo currentAnimation;

        private void Awake()
        {
            GameObject.FindGameObjectWithTag("SoulSpawner").GetComponent<SoulSpawner>().sendSoulHandler += RegisterNewSoul;

            //Borrar. Solo por temas de debug
            soul = GameObject.FindGameObjectWithTag("Soul");
        }

        public void RegisterNewSoul(object sender, GameObject newSoul)
        {
            this.soul = newSoul;
        }

        public void ActivateCinematic(int n)
        {
            this.mode = n;

            switch(mode)
            {
                case 0:
                    SoulMode();
                    break;
                case 1:
                    break;
                default:
                    break;

            }

        }

        public void ResetCinematic()
        {
            this.n = -1;
        }

        private void SoulMode()
        {
            n++;
            soul.GetComponent<Animator>().SetInteger("animationNumber", n);
            currentAnimation = soul.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        }
    }
}