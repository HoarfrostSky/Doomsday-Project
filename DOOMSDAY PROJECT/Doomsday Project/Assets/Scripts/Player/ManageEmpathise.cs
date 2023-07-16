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
        private Dictionary<String, Sprite[]> memorySpritesDictionary = new Dictionary<String, Sprite[]>() { };
        private Dictionary<String, String[]> memoryDialogueDictionary = new Dictionary<String, String[]>() { };
        private bool memoryAvailable = false;
        private ASoul soul;

        public String[] memoryNames;
        public Sprite[] carAccidentMemorySprites;
        public String[] carAccidentMemoryDialogue;
        public Sprite[] bullyingMemorySprites;
        public String[] bullyingMemoryDialogue;

        private void Awake()
        {
            playerStateController = GetComponentInParent<PlayerStateController>();
            dialogueManager = GetComponentInParent<DialogueManager>();
            dialogueManager.memoryHandler += RecieveMemory;

            memorySpritesDictionary.Add(memoryNames[0], carAccidentMemorySprites);
            memoryDialogueDictionary.Add(memoryNames[0], carAccidentMemoryDialogue);
            memorySpritesDictionary.Add(memoryNames[1], bullyingMemorySprites);
            memoryDialogueDictionary.Add(memoryNames[1], bullyingMemoryDialogue);
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

        public Sprite[] GetCurrentMemorySprites()
        {
            return memorySpritesDictionary[currentMemory];
        }
        public String[] GetCurrentMemoryDialogue()
        {
            return memoryDialogueDictionary[currentMemory];
        }
    }
}
