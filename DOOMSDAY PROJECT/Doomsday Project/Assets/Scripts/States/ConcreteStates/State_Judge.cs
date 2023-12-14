using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States.Interfaces;
using Music;
using System;
using CameraNamespace;
using ControlManager = Controls.ControlManager;

namespace States.ConcreteStates
{
    public class State_Judge : AConcreteState
    {
        private GameObject judgeUIGO;
        private ManageMusic musicManager;

        public EventHandler<int> CameraHandler;

        public State_Judge(IPlayerState playerState) : base(playerState)
        {
            this.name = "State_Judge";
        }

        public override void Enter()
        {
            Debug.Log("Entering State_Judge");

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DramaManager>().ConnectJudgeStateHandler(this);
            CameraHandler.Invoke(this, 3);

            judgeUIGO = GameObject.FindGameObjectWithTag("Judge");
            judgeUIGO.transform.localScale = new Vector3(0.4f, 0.4f, 1f);

            musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<ManageMusic>();
            musicManager.StartJudgeMusic(0f, 30f);
        }

        public override void Exit()
        {
            Debug.Log("Exiting State_Judge");

            judgeUIGO.transform.localScale = new Vector3(0f, 0f, 1f);
        }

        public override void Update()
        {
            controlManager.JudgeControls(this, playerState);
        }
    }
}