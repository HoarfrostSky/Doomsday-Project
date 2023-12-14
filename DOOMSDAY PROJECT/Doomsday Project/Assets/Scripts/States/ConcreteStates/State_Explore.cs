using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using States.Interfaces;
using Cinematic;
using Music;
using CameraNamespace;

namespace States.ConcreteStates
{
    public class State_Explore : AConcreteState
    {
        private Animator playerAnim;
        private GameObject cinemaManager;
        private ManageMusic musicManager;

        public State_Explore(IPlayerState playerState) : base(playerState)
        {
            this.name = "State_Explore";
        }

        public override void Enter()
        {
            Debug.Log("Entering State_Explore");

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DramaManager>().ExecuteCameraMovement(this, 0);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovementManager>().SetEnableMovement(true);

            playerAnim = playerGO.GetComponent<Animator>();
            playerAnim.SetTrigger("RevertToIdle");

            if (cinemaManager == null) cinemaManager = GameObject.FindGameObjectWithTag("CinemaManager");
            cinemaManager.GetComponent<ManageCinema>().ResetCinematic();

            musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<ManageMusic>();
            musicManager.JudgeMusicVolume(20f, 0f);
        }

        public override void Exit()
        {
            Debug.Log("Exiting State_Explore");
            gameManager.ChangeInteractUI(new Vector3(0f, 0f, 1f));
        }

        public override void Update()
        {
            controlManager.ExploreControls(this, playerState, rb, playerAnim);
        }
    }
}