using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Interactuables.Interfaces;
using States.Controllers;
using States.ConcreteStates;
using Dialogue;
using Localization;
using Scenes.Controllers;

namespace Interactuables.ConcreteInteractuables
{
    public class Interactuable_Dark1 : AInteractuable
    {
        public TextAsset textAssetData;

        private int currentDialogue = 0;

        private Dictionary<int, String[]> dialogueDicitonary = new Dictionary<int, string[]> { };

        private void Start()
        {
            localization.LoadLocalization(FindObjectOfType<SceneStateController>()?.GetLanguage(), textAssetData, dialogueDicitonary);
        }

        public override void Interact()
        {
            colGO.GetComponent<PlayerStateController>().SetState(new State_Dialogue(colGO.GetComponent<PlayerStateController>()));
            GameObject.FindGameObjectWithTag("Player").GetComponent<DialogueManager>().RecieveMessage(this, dialogueDicitonary[currentDialogue]);
        }

        public void PrepareNextDialogue()
        {
            this.currentDialogue++;
        }
    }
}
