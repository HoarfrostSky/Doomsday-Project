using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blame.Interfaces;
using Interactuables.Interfaces;
using States.ConcreteStates;
using States.Controllers;
using End;
using System;
using UnityEngine.SceneManagement;
using Scenes.Controllers;

namespace Interactuables.ConcreteInteractuables
{
    public class Interactuable_TrinketPile : AInteractuable
    {
        private GameObject blameTrinket;
        public GameObject foregroundEffectsGameObject;
        public GameObject groundGameObject;
        public GameObject throne;
        public TextAsset textAssetData;

        private int dialoguePointer = 0;

        private Dictionary<int, String[]> dialogueDicitonary = new Dictionary<int, string[]> { };

        private void Start()
        {
            localization.LoadLocalization(FindObjectOfType<SceneStateController>()?.GetLanguage(), textAssetData, dialogueDicitonary);
        }

        public void ConnectNextTrinket(GameObject trinket)
        {
            this.blameTrinket = trinket;
        }
        public override void Interact()
        {
            if (blameTrinket != null && blameTrinket.GetComponent<ABlameTrinket>().IsPlayerCarryingTrinket())
            {
                GetComponent<AudioSource>().Play();

                FindObjectOfType<Interactuable_Book>().PrepareNextDialogue();
                FindObjectOfType<BlameDialogueScript>().Activate();

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
                        foregroundEffectsGameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.4f);
                        groundGameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0.95f, 0.95f, 1f);
                        break;
                    case 3: //Nur
                        break;
                    case 4: //Bretta
                        GetComponent<Animator>().SetTrigger("TrinketPile4");
                        foregroundEffectsGameObject.GetComponent<Animator>().SetTrigger("Condemn2");
                        foregroundEffectsGameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.6f);
                        groundGameObject.GetComponent<SpriteRenderer>().color = new Color(0.9f, 0.7f, 0.7f, 1f);
                        break;
                    case 5: //Hayure
                        GetComponent<Animator>().SetTrigger("TrinketPile5");
                        foregroundEffectsGameObject.GetComponent<Animator>().SetTrigger("Condemn3");
                        foregroundEffectsGameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);
                        groundGameObject.GetComponent<SpriteRenderer>().color = new Color(0.75f, 0.4f, 0.4f, 1f);
                        break;
                    case 6: //Colin
                        GetComponent<Animator>().SetTrigger("TrinketPile6");
                        foregroundEffectsGameObject.GetComponent<Animator>().SetTrigger("Condemn4");
                        foregroundEffectsGameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                        groundGameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0f, 0f, 1f);
                        break;
                    case 7: //Nur father
                        break;
                    case 8: //Lenna
                        SceneManager.LoadScene("EndScene");
                        GetComponent<ChangeToEnd>().End();
                        
                        break;

                }

                Debug.Log("Se destruye blame trinket");
                Destroy(blameTrinket);

                throne.GetComponent<Interactuable_Throne>().SetCanSpawnSoul(true);
            }
            else
            {
                colGO.GetComponent<PlayerStateController>().SetState(new State_Dialogue(colGO.GetComponent<PlayerStateController>()));
                SendMessageHandler?.Invoke(this, dialogueDicitonary[dialoguePointer]);
            }
        }
    }
}
