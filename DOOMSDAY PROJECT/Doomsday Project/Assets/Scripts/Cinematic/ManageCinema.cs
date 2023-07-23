using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Souls;
using Souls.Interfaces;
using CameraNamespace;
using States.ConcreteStates;
using States.Controllers;

namespace Cinematic
{
    public class ManageCinema : MonoBehaviour
    {
        private int mode = 0;
        private int n = -1;
        private GameObject soul;
        private AnimatorStateInfo currentAnimation;

        public GameObject introGO;

        public String[] harnAnimationList;
        public String[] strangeAnimationList;
        public String[] nurAnimationList;
        public String[] brettaAnimationList;
        public String[] hayureAnimationList;
        public String[] colinAnimationList;
        public String[] lennaAnimationList;

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
                    StartCoroutine(ManageTitleIntro());
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
                case 5:
                    soul.GetComponent<Animator>().SetTrigger(hayureAnimationList[n]);
                    break;
                case 6:
                    soul.GetComponent<Animator>().SetTrigger(colinAnimationList[n]);
                    break;
                case 8:
                    soul.GetComponent<Animator>().SetTrigger(lennaAnimationList[n]);
                    break;
            }

            currentAnimation = soul.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        }

        IEnumerator ManageTitleIntro()
        {
            DramaManager cameraScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DramaManager>();
            GameObject.Find("Dark2").transform.localScale = new Vector3(0f, 0f, 1f);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("SitRight");

            cameraScript.gameObject.transform.localPosition = new Vector3(-2.06f, 17.07f, -10f);
            cameraScript.ExecuteCameraMovement(this, 9);

            yield return new WaitForSeconds(5f);

            cameraScript.ExecuteCameraMovement(this, 10);

            yield return new WaitForSeconds(36f);

            cameraScript.CallFadeOut();

            yield return new WaitForSeconds(3f);

            cameraScript.ExecuteCameraMovement(this, 0);

            yield return new WaitForSeconds(2f);

            PlayerStateController playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateController>();
            playerController.SetState(new State_Explore(playerController));

            yield return new WaitForSeconds(0.5f);

            introGO.SetActive(false);
            GameObject.Find("Dark2").transform.localScale = new Vector3(1f, 1f, 1f);
            cameraScript.CallFadeIn();
        }
    }
}