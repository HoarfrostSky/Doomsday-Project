using System.Collections;
using System.Collections.Generic;
using Dialogue;
using System;
using UnityEngine;
using States.Interfaces;
using Interactuables.Interfaces;
using Cinematic;

namespace States.ConcreteStates
{
    public class State_Explore : AConcreteState
    {
        private IInteractuable interactor;
        private GameObject showInteractGO;
        private Animator playerAnim;
        private GameObject soul;
        private GameObject cinemaManager;

        public State_Explore(IPlayerState playerState) : base(playerState)
        {
            this.name = "State_Explore";
        }

        public override void Enter()
        {
            Debug.Log("Entering State_Explore");

            playerAnim = playerGO.GetComponent<Animator>();
            playerAnim.SetTrigger("RevertToIdle");

            soul = GameObject.FindGameObjectWithTag("Soul");
            if(soul != null) MonoBehaviour.Destroy(soul);

            if (cinemaManager == null) cinemaManager = GameObject.FindGameObjectWithTag("CinemaManager");
            cinemaManager.GetComponent<ManageCinema>().ResetCinematic();

            GameObject[] listaInteractuables = GameObject.FindGameObjectsWithTag("Interactuable");
            foreach (GameObject GO in listaInteractuables)
            {
                GO.GetComponent<AInteractuable>().InteractorHandler += RecieveInteractor;
            }

            showInteractGO = GameObject.FindGameObjectWithTag("ShowInteract");

            showInteractGO.transform.localScale = new Vector3(0f, 0f, 1f);
        }

        public override void Exit()
        {
            Debug.Log("Exiting State_Explore");

            showInteractGO.transform.localScale = new Vector3(0f, 0f, 1f);
        }

        public override void Update()
        {
            controlManager.ExploreControls(this, playerState, interactor, rb, playerAnim);
        }

        public void RecieveInteractor(object sender, IInteractuable interactorObject)
        {
            this.interactor = interactorObject;
        }
    }
}