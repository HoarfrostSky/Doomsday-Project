using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States.Interfaces;
using Music;
using ControlManager = Controls.ControlManager;

namespace States.ConcreteStates
{
    public class State_Judge : AConcreteState
    {
        private GameObject judgeUIGO;
        private ManageMusic musicManager;
        public State_Judge(IPlayerState playerState) : base(playerState)
        {
            this.name = "State_Judge";
        }

        public override void Enter()
        {
            Debug.Log("Entering State_Judge");

            judgeUIGO = GameObject.FindGameObjectWithTag("Judge");
            judgeUIGO.transform.localScale = new Vector3(1f, 1f, 1f);

            musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<ManageMusic>();
            musicManager.StartJudgeMusic(0f, 10f);
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

        public override void RegisterInteractor(GameObject newInteractor)
        {
        }
    }
}