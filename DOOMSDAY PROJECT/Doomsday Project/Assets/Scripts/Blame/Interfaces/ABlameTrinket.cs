using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactuables.Interfaces;
using Interactuables.ConcreteInteractuables;
using States.ConcreteStates;
using States.Controllers;
using System;
using Interact = Interactuables.Interfaces.IInteractuable;
using Localization;
using Scenes.Controllers;

namespace Blame.Interfaces
{
    public class ABlameTrinket : AInteractuable
    {
        public int id = 0;
        protected bool carryingTrinket = false;

        public TextAsset textAssetData;
        private Dictionary<int, String[]> dialogueDicitonary = new Dictionary<int, string[]> { };

        private void Start()
        {
            localization.LoadLocalization(FindObjectOfType<SceneStateController>()?.GetLanguage(), textAssetData, dialogueDicitonary);
        }

        public override void Interact()
        {
            Debug.Log("Se interactúa con trinket");

            GetComponent<AudioSource>().Play();

            this.transform.localScale = new Vector3(0f, 0f, 1f);
            GetComponent<Collider2D>().enabled = false;

            GameObject.Find("TrinketPile").GetComponent<Interactuable_TrinketPile>().ConnectNextTrinket(this.gameObject);

            colGO.GetComponent<PlayerStateController>().SetState(new State_Dialogue(colGO.GetComponent<PlayerStateController>()));
            Debug.Log("Dialogo a enviar:" + dialogueDicitonary[0]);
            SendMessageHandler?.Invoke(this, dialogueDicitonary[0]);

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
