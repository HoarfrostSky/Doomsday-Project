using Interactuables.Interfaces;
using System;
using Controls;
using Souls.Interfaces;
using States.ConcreteStates;
using States.Controllers;
using UnityEngine;

namespace Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        private String[] dialogueTexts;
        private int nDialogue = -1;

        public EventHandler<String> dialogueHandler;
        public EventHandler<String> iconHandler;
        public EventHandler<String> memoryHandler;

        private void Awake()
        {
            GameObject[] listaInteractuables = GameObject.FindGameObjectsWithTag("Interactuable");
            foreach (GameObject GO in listaInteractuables)
            {
                GO.GetComponent<AInteractuable>().SendMessageHandler += RecieveMessage;
            }
        }

        public void RecieveMessage(object sender, String[] dialogue)
        {
            dialogueTexts = dialogue;
            NextMessage();
        }

        public void ConnectSoul(ASoul soul)
        {
            soul.sendDialogueHandler += RecieveMessage;
        }

        public void ProcessMessage(int i)
        {
            String text = dialogueTexts[i];
            String[] processedText = text.Split("-");

            if(processedText[0] == "cinematic") //If a cinematic is called from the dialogue input
            {
                GetComponent<PlayerStateController>().SetState(new State_Cinematic(GetComponent<PlayerStateController>()));
            }
            else if(processedText[0] == "judge")
            {
                nDialogue = -1;
                dialogueTexts = null;
                GetComponent<PlayerStateController>().SetState(new State_Judge(GetComponent<PlayerStateController>()));
            }
            else
            {
                String[] processedText2 = processedText[1].Split("*");

                if(processedText2.Length > 1) //If there's a memory event called from the dialogue input
                {
                    memoryHandler?.Invoke(this, processedText2[1]);
                }

                ShowIcon(processedText[0]);
                ShowText(processedText2[0]);
            }
        }

        public void NextMessage()
        {
            nDialogue++;

            if (nDialogue == dialogueTexts.Length)
            {
                nDialogue = -1;
                dialogueTexts = null;
                GetComponent<PlayerStateController>().SetState(new State_Explore(GetComponent<PlayerStateController>()));
            }
            else
            {
                ProcessMessage(nDialogue);
            }
        }

        private void ShowIcon(String iconName)
        {
            iconHandler?.Invoke(this, iconName);
        }

        private void ShowText(String dialogueText)
        {
            dialogueHandler?.Invoke(this, dialogueText);
        }
    }
}