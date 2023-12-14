using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States.ConcreteStates;
using States.Controllers;
using Souls.Interfaces;

namespace Souls
{
    public class SaveAnimationManager : MonoBehaviour
    {
        private Animator soulParent;
        private GameObject soulParentGO;
        private PlayerStateController playerState;

        private void Awake()
        {
            soulParentGO = GameObject.FindGameObjectWithTag("Soul");
            soulParent = soulParentGO.GetComponent<Animator>();
            playerState = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateController>();
        }

        public void SaveSoul()
        {
            soulParent.SetTrigger("Save");
        }

        public void Dark1CastSpell()
        {
            GameObject.Find("Dark1").GetComponent<Animator>().SetTrigger("CastSpell");
            
        }

        public void PlaySpellSound()
        {
            GetComponent<AudioSource>().volume = 0.6f;
            //GetComponent<AudioSource>().Play();
        }

        public void Dark1RevertToIdle()
        {
            GameObject.Find("Dark1").GetComponent<Animator>().SetTrigger("RevertToIdle");
        }

        public void ResetToExplore()
        {
            playerState.SetState(new State_Explore(playerState));
        }
    }
}
