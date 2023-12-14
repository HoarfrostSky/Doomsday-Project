using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using States.Interfaces;
using Player;
using TMPro;

namespace States.ConcreteStates
{
    public class State_Memory : AConcreteState
    {
        private ManageEmpathise manageEmpathise;

        private GameObject memoryGO;
        private GameObject cameraGO;
        private ManageMemory memoryManager;

        public EventHandler<String> dialogueHandler;

        public State_Memory(IPlayerState playerState) : base(playerState)
        {
            this.name = "State_Memory";
        }

        public override void Enter()
        {
            Debug.Log("Entering State_Memory");

            manageEmpathise = playerGO.GetComponentInChildren<ManageEmpathise>();
            manageEmpathise.gameObject.transform.localScale = new Vector3(0f, 0f, 1f);

            memoryGO = GameObject.FindGameObjectWithTag("Memory");
            memoryManager = memoryGO.GetComponent<ManageMemory>();
            memoryGO.transform.localScale = new Vector3(1f, 1f, 1f);
            cameraGO = GameObject.FindGameObjectWithTag("MainCamera");
            memoryGO.transform.position = new Vector3(cameraGO.transform.position.x, cameraGO.transform.position.y, memoryGO.transform.position.z);

            memoryManager.RecieveMemoryData(playerState, manageEmpathise.GetCurrentMemoryDialogue(), memoryGO.GetComponentInChildren<TextMeshPro>());
        }

        public override void Exit()
        {
            Debug.Log("Exiting State_Memory");

            manageEmpathise.PlayEndMemorySound();
            memoryGO.transform.localScale = new Vector3(0f, 0f, 1f);
        }

        public override void Update()
        {
            controlManager.MemoryControls(this, playerState);
        }
    }
}