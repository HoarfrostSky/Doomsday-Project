using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blame.Interfaces;
using Interactuables.Interfaces;
using States.ConcreteStates;
using States.Controllers;

namespace Interactuables.ConcreteInteractuables
{
    public class Interactuable_TrinketPile : AInteractuable
    {
        private GameObject blameTrinket;

        public void ConnectNextTrinket(GameObject trinket)
        {
            this.blameTrinket = trinket;
        }
        public override void Interact()
        {
            if (blameTrinket != null && blameTrinket.GetComponent<ABlameTrinket>().IsPlayerCarryingTrinket())
            {
                switch (blameTrinket.GetComponent<ABlameTrinket>().GetID())
                {
                    case 0: //Random
                        break;
                    case 1: //Harn
                        GetComponent<Animator>().SetTrigger("TrinketPile2");
                        break;
                    case 2: //Strange
                        GetComponent<Animator>().SetTrigger("TrinketPile3");
                        break;
                    case 3: //Nur
                        break;
                    case 4: //Bretta
                        GetComponent<Animator>().SetTrigger("TrinketPile4");
                        break;
                    case 5: //Hayure
                        GetComponent<Animator>().SetTrigger("TrinketPile5");
                        break;
                    case 6: //Colin
                        GetComponent<Animator>().SetTrigger("TrinketPile6");
                        break;
                    case 7: //Nur father
                        break;
                    case 8: //Lenna
                        break;

                }

                Debug.Log("Se destruye blame trinket");
                Destroy(blameTrinket);
            }
            else
            {
                colGO.GetComponent<PlayerStateController>().SetState(new State_Dialogue(colGO.GetComponent<PlayerStateController>()));
                SendMessageHandler?.Invoke(this, dialogue);
            }
        }
    }
}
