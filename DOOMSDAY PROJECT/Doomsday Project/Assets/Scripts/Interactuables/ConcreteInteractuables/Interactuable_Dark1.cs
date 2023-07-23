using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Interactuables.Interfaces;
using States.Controllers;
using States.ConcreteStates;
using Dialogue;

namespace Interactuables.ConcreteInteractuables
{
    public class Interactuable_Dark1 : AInteractuable
    {
        public String[] dialogue0;
        public String[] dialogue1;
        public String[] dialogue2;
        public String[] dialogue3;
        public String[] dialogue4;

        private int currentDialogue = 0;

        private Dictionary<int, String[]> dialogueDicitonary = new Dictionary<int, string[]> { };

        private void Start()
        {
            dialogueDicitonary.Add(0, dialogue0);
            dialogueDicitonary.Add(1, dialogue1);
            dialogueDicitonary.Add(2, dialogue2);
            dialogueDicitonary.Add(3, dialogue3);
            dialogueDicitonary.Add(4, dialogue4);
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
