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

        private void OnDestroy()
        {
            GameObject trinketContainer = GameObject.FindGameObjectWithTag("TrinketContainer");
            //trinketContainer.GetComponent<ManageTrinketContainer>().Relocate(this.transform.position);
            blameTrinketGO = Instantiate(blameTrinket, trinketContainer.transform);
            blameTrinketGO.GetComponent<SpriteRenderer>().sprite = randomTrinketSprites[(int) UnityEngine.Random.Range(0, randomTrinketSprites.Length - 1)];
        }
    }
}
