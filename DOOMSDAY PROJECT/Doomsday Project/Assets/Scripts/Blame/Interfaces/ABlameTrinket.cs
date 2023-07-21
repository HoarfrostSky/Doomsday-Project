using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactuables.Interfaces;
using Interactuables.ConcreteInteractuables;
using States.ConcreteStates;
using States.Controllers;

namespace Blame.Interfaces
{
    public class ABlameTrinket : AInteractuable
    {
        public int id = 0;
        protected bool carryingTrinket = false;

        public override void Interact()
        {
            Debug.Log("Se interactúa con trinket");

            this.transform.localScale = new Vector3(0f, 0f, 1f);
            GetComponent<Collider2D>().enabled = false;

            GameObject.Find("TrinketPile").GetComponent<Interactuable_TrinketPile>().ConnectNextTrinket(this.gameObject);

            colGO.GetComponent<PlayerStateController>().SetState(new State_Dialogue(colGO.GetComponent<PlayerStateController>()));
            Debug.Log("Dialogo a enviar:" + dialogue[0]);
            SendMessageHandler?.Invoke(this, dialogue);

            carryingTrinket = true;
        }

        public bool IsPlayerCarryingTrinket()
        {
            return carryingTrinket;
        }

        public int GetID()
        {
            return id;
        }
    }
}
