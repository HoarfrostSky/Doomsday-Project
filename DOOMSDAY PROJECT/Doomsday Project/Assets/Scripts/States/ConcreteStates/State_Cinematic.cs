using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Player;
using States.Interfaces;
using Cinematic;
using ControlManager = Controls.ControlManager;

namespace States.ConcreteStates
{
    public class State_Cinematic : AConcreteState
    {
        private ManageEmpathise manageEmpathise;

        private ManageCinema cinemaManager;
        private RectTransform dialogueUIGO;

        public State_Cinematic(IPlayerState playerState) : base(playerState)
        {
            this.name = "State_Cinematic";
        }

        public override void Enter()
        {
            Debug.Log("Entering State_Cinematic");

            manageEmpathise = playerGO.GetComponentInChildren<ManageEmpathise>();
            manageEmpathise.gameObject.transform.localScale = new Vector3(0f, 0f, 1f);

            dialogueUIGO = GameObject.FindGameObjectWithTag("DialogueUI").GetComponent<RectTransform>();

            if (cinemaManager == null) cinemaManager = GameObject.FindGameObjectWithTag("CinemaManager").GetComponent<ManageCinema>();

            cinemaManager.ActivateCinematic(0);
        }

        public override void Exit()
        {
            Debug.Log("Exiting State_Cinematic");
        }

        public override void Update()
        {
            dialogueUIGO.localScale = new Vector3(0f, 0f, 1f);
            controlManager.CinematicControls(this, playerState);
        }
    }
}