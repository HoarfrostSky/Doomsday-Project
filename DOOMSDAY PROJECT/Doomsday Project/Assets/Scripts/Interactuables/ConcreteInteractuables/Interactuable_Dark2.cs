using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactuables.Interfaces;
using States.Controllers;
using States.ConcreteStates;

namespace Interactuables.ConcreteInteractuables
{
    public class Interactuable_Dark2 : AInteractuable
    {
        public override void Interact()
        {
            colGO.GetComponent<PlayerStateController>().SetState(new State_Dialogue(colGO.GetComponent<PlayerStateController>()));
            SendMessageHandler?.Invoke(this, dialogue);
        }
    }
}
