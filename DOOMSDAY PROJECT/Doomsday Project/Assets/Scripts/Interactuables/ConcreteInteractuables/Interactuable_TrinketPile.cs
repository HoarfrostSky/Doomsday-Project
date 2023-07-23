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
        public GameObject foregroundEffectsGameObject;
        public GameObject throne;

        public void ConnectNextTrinket(GameObject trinket)
        {
            this.blameTrinket = trinket;
        }
        public override void Interact()
        {
            if (blameTrinket != null && blameTrinket.GetComponent<ABlameTrinket>().IsPlayerCarryingTrinket())
            {
                GetComponent<AudioSource>().Play();

                switch (blameTrinket.GetComponent<ABlameTrinket>().GetID())
                {
                    case 0: //Random
                        break;
                    case 1: //Harn
                        GetComponent<Animator>().SetTrigger("TrinketPile2");
                        break;
                    case 2: //Strange
                        GetComponent<Animator>().SetTrigger("TrinketPile3");
                        foregroundEffectsGameObject.GetComponent<Animator>().SetTrigger("Condemn1");
                        break;
                    case 3: //Nur
                        break;
                    case 4: //Bretta
                        GetComponent<Animator>().SetTrigger("TrinketPile4");
                        foregroundEffectsGameObject.GetComponent<Animator>().SetTrigger("Condemn2");
                        break;
                    case 5: //Hayure
                        GetComponent<Animator>().SetTrigger("TrinketPile5");
                        foregroundEffectsGameObject.GetComponent<Animator>().SetTrigger("Condemn3");
                        break;
                    case 6: //Colin
                        GetComponent<Animator>().SetTrigger("TrinketPile6");
                        foregroundEffectsGameObject.GetComponent<Animator>().SetTrigger("Condemn4");
                        break;
                    case 7: //Nur father
                        break;
                    case 8: //Lenna
                        break;

                }

                Debug.Log("Se destruye blame trinket");
                Destroy(blameTrinket);

                throne.GetComponent<Interactuable_Throne>().SetCanSpawnSoul(true);
            }
            else
            {
                colGO.GetComponent<PlayerStateController>().SetState(new State_Dialogue(colGO.GetComponent<PlayerStateController>()));
                SendMessageHandler?.Invoke(this, dialogue);
            }
        }
    }
}
