using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Souls;
using Souls.Interfaces;

namespace Cinematic
{
    public class ManageCinema : MonoBehaviour
    {
        private int mode = 0;
        private int n = -1;
        private GameObject soul;
        private AnimatorStateInfo currentAnimation;

        public String[] harnAnimationList;
        public String[] strangeAnimationList;
        public String[] nurAnimationList;
        public String[] brettaAnimationList;

        private void Awake()
        {
            GameObject.FindGameObjectWithTag("SoulSpawner").GetComponent<SoulSpawner>().sendSoulHandler += RegisterNewSoul;
            soul = GameObject.FindGameObjectWithTag("Soul");
        }

        public void RegisterNewSoul(object sender, GameObject newSoul)
        {
            this.soul = newSoul;
        }

        public void ActivateCinematic(int modeNumber)
        {
            this.mode = modeNumber;

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

            switch(soul.GetComponent<ASoul>().GetID())
            {
                case 1:
                    soul.GetComponent<Animator>().SetTrigger(harnAnimationList[n]);
                    break;
                case 2:
                    soul.GetComponent<Animator>().SetTrigger(strangeAnimationList[n]);
                    break;
                case 3:
                    soul.GetComponent<Animator>().SetTrigger(nurAnimationList[n]);
                    break;
                case 4:
                    soul.GetComponent<Animator>().SetTrigger(brettaAnimationList[n]);
                    break;
            }

            currentAnimation = soul.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        }
    }
}