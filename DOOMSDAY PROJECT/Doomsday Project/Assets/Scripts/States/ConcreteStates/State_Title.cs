using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States.Interfaces;
using Music;
using System;
using ControlManager = Controls.ControlManager;
using Cinematic;

namespace States.ConcreteStates
{
    public class State_Title : AConcreteState
    {
        public State_Title(IPlayerState playerState) : base(playerState)
        {
            this.name = "State_Title";
        }

        public override void Enter()
        {
            Debug.Log("Entering State_Title");

            GameObject.FindGameObjectWithTag("CinemaManager").GetComponent<ManageCinema>().ActivateCinematic(1);
        }

        public override void Exit()
        {
            Debug.Log("Exiting State_Title");
        }

        public override void Update()
        {

        }
    }
}