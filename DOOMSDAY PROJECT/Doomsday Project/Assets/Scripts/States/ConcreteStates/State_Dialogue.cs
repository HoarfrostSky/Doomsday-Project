using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dialogue;
using States.Interfaces;
using Player;
using ControlManager = Controls.ControlManager;

namespace States.ConcreteStates
{
    public class State_Dialogue : AConcreteState
    {
        private DialogueManager dialogueManager;
        private ManageEmpathise manageEmpathise;
        private GameObject dialogueUIGO;

        public State_Dialogue(IPlayerState playerState) : base(playerState)
        {
            this.name = "State_Dialogue";
        }

        public override void Enter()
        {
            Debug.Log("Entering State_Dialogue");

                dialogueManager = playerGO.GetComponent<DialogueManager>();
                dialogueUIGO = GameObject.FindGameObjectWithTag("DialogueUI");
                dialogueUIGO.GetComponentInChildren<DialogueUI>().ConnectDialogue(dialogueManager);
                dialogueUIGO.GetComponentInChildren<IconUI>().ConnectDialogue(dialogueManager);
                manageEmpathise = playerGO.GetComponentInChildren<ManageEmpathise>();

            if(playerState.GetPreviousState().GetName() == "State_Memory" || playerState.GetPreviousState().GetName() == "State_Cinematic")
            {
                dialogueManager.NextMessage();
            }

            dialogueUIGO.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        }

        public override void Exit()
        {
            Debug.Log("Exiting State_Dialogue");

            if (playerState.GetNextState().GetName() != "State_Cinematic" && playerState.GetNextState().GetName() != "State_Memory")
            {
                Debug.Log("Se vacían los textos.");
                dialogueManager.EmptyTexts();
            }

            manageEmpathise.gameObject.transform.localScale = new Vector3(0f, 0f, 1f);
            dialogueUIGO.GetComponent<RectTransform>().localScale = new Vector3(0f, 0f, 1f);
        }

        public override void Update()
        {
            controlManager.DialogueControls(this, playerState, dialogueManager, dialogueUIGO.GetComponentInChildren<DialogueUI>(), manageEmpathise);
        }

        public override void RegisterInteractor(GameObject newInteractor)
        {
        }
    }
}