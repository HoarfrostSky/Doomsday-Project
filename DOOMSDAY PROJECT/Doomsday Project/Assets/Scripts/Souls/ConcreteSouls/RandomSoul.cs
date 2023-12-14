using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Souls.Interfaces;
using Dialogue;

namespace Souls.ConcreteSouls
{
    public class RandomSoul : ASoul
    {
        public Sprite[] randomTrinketSprites;
        private GameObject blameTrinketGO;

        private void Awake()
        {
            playerGO = GameObject.FindGameObjectWithTag("Player");
            playerGO.GetComponent<DialogueManager>().ConnectSoul(this);

            for (int i = 0; i < dialogueDict.Count; i++)
            {
                dialogue[i] = dialogueDict[i];
            }
        }

        private void OnDestroy()
        {
            GameObject trinketContainer = GameObject.FindGameObjectWithTag("TrinketContainer");
            blameTrinketGO = Instantiate(blameTrinket, trinketContainer.transform);
            blameTrinketGO.GetComponent<SpriteRenderer>().sprite = randomTrinketSprites[(int) UnityEngine.Random.Range(0, randomTrinketSprites.Length - 1)];
        }

    }
}
