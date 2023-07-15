using Interactuables.Interfaces;
using States.Controllers;
using States.ConcreteStates;
using System;
using Souls;
using UnityEngine;

namespace Interactuables.ConcreteInteractuables
{
    public class Interactuable_Throne : AInteractuable
    {
        public override void Interact()
        {
            //colGO.GetComponent<PlayerStateController>().SetState(new State_Dialogue(colGO.GetComponent<PlayerStateController>()));
            //SendMessageHandler?.Invoke(this, dialogue);

            GameObject.FindGameObjectWithTag("SoulSpawner").GetComponent<SoulSpawner>().SpawnSoul();
        }
    }
}
