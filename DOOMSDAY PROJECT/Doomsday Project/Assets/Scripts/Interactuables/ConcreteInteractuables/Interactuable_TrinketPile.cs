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
            if (blameTrinket.GetComponent<ABlameTrinket>().IsPlayerCarryingTrinket())
            {
                switch(blameTrinket.GetComponent<ABlameTrinket>().GetID())
                {
                    case 0: //Random
                        break;
                    case 1: //Harn
                        break;
                    case 2: //Strange
                        break;
                    case 3: //Nur
                        break;
                    case 4: //Bretta
                        break;
                    case 5: //Hayure
                        break;
                    case 6: //Colin
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
