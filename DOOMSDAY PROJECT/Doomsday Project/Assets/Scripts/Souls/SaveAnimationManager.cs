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

        public void ResetToExplore()
        {
            playerState.SetState(new State_Explore(playerState));
        }
    }
}
