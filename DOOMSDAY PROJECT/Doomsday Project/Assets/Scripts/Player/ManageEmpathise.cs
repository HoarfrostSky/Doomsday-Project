using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using States.Controllers;
using States.ConcreteStates;
using Dialogue;
using Souls.Interfaces;

namespace Player
{
    public class ManageEmpathise : MonoBehaviour
    {
        private PlayerStateController playerStateController;
        private DialogueManager dialogueManager;
        private String currentMemory;
        private Dictionary<String, String[]> memoryDialogueDictionary = new Dictionary<String, String[]>() { };
        private bool memoryAvailable = false;
        private ASoul soul;

        public String[] memoryNames;
        public String[] carAccidentMemoryDialogue;
        public String[] bullyingMemoryDialogue;
        public String[] dreamsOfAdventureMemoryDialogue;
        public String[] killingsMemoryDialogue;
        public String[] colinPastMemoryDialogue;
        public String[] truthMemoryDialogue;

        private void Awake()
        {
            playerStateController = GetComponentInParent<PlayerStateController>();
            dialogueManager = GetComponentInParent<DialogueManager>();
            dialogueManager.memoryHandler += RecieveMemory;

            memoryDialogueDictionary.Add(memoryNames[0], carAccidentMemoryDialogue);
            memoryDialogueDictionary.Add(memoryNames[1], bullyingMemoryDialogue);
            memoryDialogueDictionary.Add(memoryNames[2], dreamsOfAdventureMemoryDialogue);
            memoryDialogueDictionary.Add(memoryNames[3], killingsMemoryDialogue);
            memoryDialogueDictionary.Add(memoryNames[4], colinPastMemoryDialogue);
            memoryDialogueDictionary.Add(memoryNames[5], truthMemoryDialogue);
        }

        public void Empathise()
        {
            soul = GameObject.FindGameObjectWithTag("Soul").GetComponent<ASoul>();
            ManageMusic(soul.GetID());

            playerStateController.SetState(new State_Memory(playerStateController));
            transform.localScale = new Vector3(0f, 0f, 1f);
            memoryAvailable = false;
        }

        private void ManageMusic(int n)
        {
            switch(n)
            {
                case 1: //Harn
                    soul.NextMusicOrders(2);
                    break;
                case 2: //Strange
                    soul.NextMusicOrders(4);
                    break;
                case 3: //Nur
                    break;
                case 4: //Bretta
                    soul.NextMusicOrders(3);
                    break;
                case 5: //Hayure
                    soul.NextMusicOrders(5);
                    break;
                case 6: //Colin
                    soul.NextMusicOrders(3);
                    break;
                case 8: //Lenna
                    soul.NextMusicOrders(4);
                    break;
            }
        }

        public void RecieveMemory(object sender, String memoryName)
        {
            this.currentMemory = memoryName;
            memoryAvailable = true;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        public bool CheckAvailability()
        {
            return memoryAvailable;
        }

        public String[] GetCurrentMemoryDialogue()
        {
            return memoryDialogueDictionary[currentMemory];
        }
    }
}
