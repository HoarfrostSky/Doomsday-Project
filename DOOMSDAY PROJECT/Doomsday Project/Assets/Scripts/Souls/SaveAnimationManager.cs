using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States.ConcreteStates;
using States.Controllers;

namespace Souls
{
    public class SaveAnimationManager : MonoBehaviour
    {
        private Animator soulParent;
        private PlayerStateController playerState;

        private void Awake()
        {
            soulParent = GameObject.FindGameObjectWithTag("Soul").GetComponent<Animator>();
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
