using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Souls.Interfaces;
using Cinematic;

namespace Souls
{
    public class SoulSpawner : MonoBehaviour
    {
        public int[] soulOrderList;
        public GameObject[] soulPrefabList;
        public GameObject soulContainerParent;

        private int soulPointer = 0;
        private GameObject currentSoul;
        private Dictionary<int, GameObject> soulDictionary = new Dictionary<int, GameObject>() { };

        public String[] randomDialogue0;
        public String[] randomDialogue1;
        public String[] randomDialogue2;
        public String[] randomDialogue3;
        public String[] randomDialogue4;
        public String[] randomDialogue5;
        public String[] randomDialogue6;
        public String[] randomDialogue7;
        public String[] randomDialogue8;
        public String[] randomDialogue9;
        public String[] randomDialogue10;
        public String[] randomDialogue11;
        public String[] randomDialogue12;
        public String[] randomDialogue13;
        public String[] randomDialogue14;
        public String[] randomDialogue15;
        public String[] randomDialogue16;
        public String[] randomDialogue17;
        public String[] randomDialogue18;
        public String[] randomDialogue19;
        public String[] randomDialogue20;
        public String[] randomDialogue21;
        public String[] randomDialogue22;
        public String[] randomDialogue23;

        public int nRandomDialogues;
        private int chosenDialogue = 0;
        private Dictionary<int, String[]> randomDialogueDictionary = new Dictionary<int, string[]>() { };

        public EventHandler<GameObject> sendSoulHandler;

        private void Awake()
        {
            for(int i = 0; i < soulPrefabList.Length; i++)
            {
                soulDictionary.Add(i, soulPrefabList[i]);
            }

            randomDialogueDictionary.Add(0, randomDialogue0);
            randomDialogueDictionary.Add(1, randomDialogue1);
            randomDialogueDictionary.Add(2, randomDialogue2);
            randomDialogueDictionary.Add(3, randomDialogue3);
            randomDialogueDictionary.Add(4, randomDialogue4);
            randomDialogueDictionary.Add(5, randomDialogue5);
            randomDialogueDictionary.Add(6, randomDialogue6);
            randomDialogueDictionary.Add(7, randomDialogue7);
            randomDialogueDictionary.Add(8, randomDialogue8);
            randomDialogueDictionary.Add(9, randomDialogue9);
            randomDialogueDictionary.Add(10, randomDialogue10);
            randomDialogueDictionary.Add(11, randomDialogue11);
            randomDialogueDictionary.Add(12, randomDialogue12);
            randomDialogueDictionary.Add(13, randomDialogue13);
            randomDialogueDictionary.Add(14, randomDialogue14);
            randomDialogueDictionary.Add(15, randomDialogue15);
            randomDialogueDictionary.Add(16, randomDialogue16);
            randomDialogueDictionary.Add(17, randomDialogue17);
            randomDialogueDictionary.Add(18, randomDialogue18);
            randomDialogueDictionary.Add(19, randomDialogue19);
            randomDialogueDictionary.Add(20, randomDialogue20);
            randomDialogueDictionary.Add(21, randomDialogue21);
            randomDialogueDictionary.Add(22, randomDialogue22);
            randomDialogueDictionary.Add(23, randomDialogue23);
        }

        public void SpawnSoul()
        {
            Debug.Log("Alma numero " + soulPointer + ", de tipo " + soulOrderList[soulPointer]);
            currentSoul = Instantiate(soulDictionary[soulOrderList[soulPointer]], soulContainerParent.transform);
            currentSoul.GetComponent<ASoul>().MoveToLocalPosition(new Vector3(15f, 0f, 0f));

            sendSoulHandler?.Invoke(this, currentSoul);

            if(soulOrderList[soulPointer] == 0)
            {
                ChooseRandomSoul();
            }

            soulPointer++;
        }

        private void ChooseRandomSoul()
        {
            currentSoul.GetComponent<ASoul>().dialogue = GenerateRandomDialogue();
        }

        private String[] GenerateRandomDialogue()
        {
            chosenDialogue = (int)UnityEngine.Random.Range(0, nRandomDialogues);
            return randomDialogueDictionary[chosenDialogue];
        }
    }
}
