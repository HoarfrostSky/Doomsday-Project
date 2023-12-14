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

        public AudioClip[] empathiseSounds;

        [TextArea(3, 10)] public String[] memoryNames;
        [TextArea(3, 10)] public String[] carAccidentMemoryDialogue;
        [TextArea(3, 10)] public String[] es_carAccidentMemoryDialogue;
        [TextArea(3, 10)] public String[] bullyingMemoryDialogue;
        [TextArea(3, 10)] public String[] es_bullyingMemoryDialogue;
        [TextArea(3, 10)] public String[] dreamsOfAdventureMemoryDialogue;
        [TextArea(3, 10)] public String[] es_dreamsOfAdventureMemoryDialogue;
        [TextArea(3, 10)] public String[] killingsMemoryDialogue;
        [TextArea(3, 10)] public String[] es_killingsMemoryDialogue;
        [TextArea(3, 10)] public String[] colinPastMemoryDialogue;
        [TextArea(3, 10)] public String[] es_colinPastMemoryDialogue;
        [TextArea(3, 10)] public String[] truthMemoryDialogue;
        [TextArea(3, 10)] public String[] es_truthMemoryDialogue;

        private void Awake()
        {
            playerStateController = GetComponentInParent<PlayerStateController>();
            dialogueManager = GetComponentInParent<DialogueManager>();
            dialogueManager.memoryHandler += RecieveMemory;

            switch(Application.systemLanguage)
            {
                case SystemLanguage.English:
                    memoryDialogueDictionary.Add(memoryNames[0], carAccidentMemoryDialogue);
                    memoryDialogueDictionary.Add(memoryNames[1], bullyingMemoryDialogue);
                    memoryDialogueDictionary.Add(memoryNames[2], dreamsOfAdventureMemoryDialogue);
                    memoryDialogueDictionary.Add(memoryNames[3], killingsMemoryDialogue);
                    memoryDialogueDictionary.Add(memoryNames[4], colinPastMemoryDialogue);
                    memoryDialogueDictionary.Add(memoryNames[5], truthMemoryDialogue);
                    break;
                case SystemLanguage.Spanish:
                    memoryDialogueDictionary.Add(memoryNames[0], es_carAccidentMemoryDialogue);
                    memoryDialogueDictionary.Add(memoryNames[1], es_bullyingMemoryDialogue);
                    memoryDialogueDictionary.Add(memoryNames[2], es_dreamsOfAdventureMemoryDialogue);
                    memoryDialogueDictionary.Add(memoryNames[3], es_killingsMemoryDialogue);
                    memoryDialogueDictionary.Add(memoryNames[4], es_colinPastMemoryDialogue);
                    memoryDialogueDictionary.Add(memoryNames[5], es_truthMemoryDialogue);
                    break;
                default:
                    memoryDialogueDictionary.Add(memoryNames[0], carAccidentMemoryDialogue);
                    memoryDialogueDictionary.Add(memoryNames[1], bullyingMemoryDialogue);
                    memoryDialogueDictionary.Add(memoryNames[2], dreamsOfAdventureMemoryDialogue);
                    memoryDialogueDictionary.Add(memoryNames[3], killingsMemoryDialogue);
                    memoryDialogueDictionary.Add(memoryNames[4], colinPastMemoryDialogue);
                    memoryDialogueDictionary.Add(memoryNames[5], truthMemoryDialogue);
                    break;
            }
        }

        public void Empathise()
        {
            soul = GameObject.FindGameObjectWithTag("Soul").GetComponent<ASoul>();
            ManageMusic(soul.GetID());

            playerStateController.SetState(new State_Memory(playerStateController));
            transform.localScale = new Vector3(0f, 0f, 1f);
            memoryAvailable = false;

            GetComponent<AudioSource>().clip = empathiseSounds[0];
            GetComponent<AudioSource>().Play();
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
            GameObject.FindGameObjectWithTag("DialogueUI").GetComponentInChildren<Animator>().SetTrigger("DialogueEmpathise");
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        public void PlayEndMemorySound()
        {
            GetComponent<AudioSource>().clip = empathiseSounds[1];
            GetComponent<AudioSource>().Play();
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
