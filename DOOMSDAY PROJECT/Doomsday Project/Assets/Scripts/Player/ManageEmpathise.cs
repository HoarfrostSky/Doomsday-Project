using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using States.Controllers;
using States.ConcreteStates;
using Dialogue;

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

        public String[] memoryNames;
        public Sprite[] carAccidentMemorySprites;
        public String[] carAccidentMemoryDialogue;

        private void Awake()
        {
            playerStateController = GetComponentInParent<PlayerStateController>();
            dialogueManager = GetComponentInParent<DialogueManager>();
            dialogueManager.memoryHandler += RecieveMemory;

            memorySpritesDictionary.Add(memoryNames[0], carAccidentMemorySprites);
            memoryDialogueDictionary.Add(memoryNames[0], carAccidentMemoryDialogue);
        }

        public void Empathise()
        {
            playerStateController.SetState(new State_Memory(playerStateController));
            transform.localScale = new Vector3(0f, 0f, 1f);
            memoryAvailable = false;
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
