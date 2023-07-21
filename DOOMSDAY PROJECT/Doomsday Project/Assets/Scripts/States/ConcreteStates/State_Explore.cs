using System.Collections;
using System.Collections.Generic;
using Dialogue;
using System;
using UnityEngine;
using States.Interfaces;
using Interactuables.Interfaces;
using Cinematic;
using Music;

namespace States.ConcreteStates
{
    public class State_Explore : AConcreteState
    {
        private IInteractuable interactor;
        private GameObject showInteractGO;
        private Animator playerAnim;
        private GameObject soul;
        private GameObject cinemaManager;
        private ManageMusic musicManager;
        private DialogueManager dialogueManager;
        private List<GameObject> interactuableList =  new List<GameObject>();

        public State_Explore(IPlayerState playerState) : base(playerState)
        {
            this.name = "State_Explore";
        }

        public override void Enter()
        {
            Debug.Log("Entering State_Explore");

            dialogueManager = playerGO.GetComponent<DialogueManager>();

            playerAnim = playerGO.GetComponent<Animator>();
            playerAnim.SetTrigger("RevertToIdle");

            soul = GameObject.FindGameObjectWithTag("Soul");
            if(soul != null) MonoBehaviour.Destroy(soul);

            if (cinemaManager == null) cinemaManager = GameObject.FindGameObjectWithTag("CinemaManager");
            cinemaManager.GetComponent<ManageCinema>().ResetCinematic();

            showInteractGO = GameObject.FindGameObjectWithTag("ShowInteract");

            GameObject[] interGOs = GameObject.FindGameObjectsWithTag("Interactuable");

            foreach(GameObject GO in interGOs)
            {
                RegisterInteractor(GO);
            }

            showInteractGO.transform.localScale = new Vector3(0f, 0f, 1f);

            musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<ManageMusic>();
            musicManager.JudgeMusicVolume(20f, 0f);
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

        public override void RegisterInteractor(GameObject newInteractor)
        {
            dialogueManager.RegisterMessageHandler(newInteractor);
            newInteractor.GetComponent<AInteractuable>().InteractorHandler += RecieveActiveInteractor;
            interactuableList.Add(newInteractor);
        }

        public void RecieveActiveInteractor(object sender, IInteractuable interactorObject)
        {
            this.interactor = interactorObject;
        }
    }
}