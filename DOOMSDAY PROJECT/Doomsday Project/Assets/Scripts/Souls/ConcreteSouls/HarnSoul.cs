using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Interactuables.ConcreteInteractuables;
using Souls.Interfaces;

namespace Souls.ConcreteSouls
{
    public class HarnSoul : ASoul
    {

        private void OnDestroy()
        {
            GameObject trinketContainer = GameObject.Find("TrinketContainer");
            //trinketContainer.GetComponent<ManageTrinketContainer>().Relocate(this.transform.position);
            Instantiate(blameTrinket, trinketContainer.transform);

            GameObject.Find("Dark1").GetComponent<Interactuable_Dark1>().PrepareNextDialogue();
            GameObject.Find("Dark2").GetComponent<Interactuable_Dark2>().PrepareNextDialogue();
        }
    }
}
