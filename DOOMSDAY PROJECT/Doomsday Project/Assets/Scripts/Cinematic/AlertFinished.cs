using System.Collections;
using System.Collections.Generic;
using States.Controllers;
using States.ConcreteStates;
using UnityEngine;

namespace Cinematic
{
    public class AlertFinished : MonoBehaviour
    {
        private PlayerStateController playerStateController;

        private void Awake()
        {
            playerStateController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateController>();
        }
        public void FinishCinematicState()
        {
            playerStateController.SetState(new State_Dialogue(playerStateController));
        }
    }
}
