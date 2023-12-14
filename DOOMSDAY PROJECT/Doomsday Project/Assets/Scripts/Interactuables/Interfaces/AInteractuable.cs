using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Dialogue;
using States.Controllers;
using Game;
using Interact = Interactuables.Interfaces.IInteractuable;
using Localization;

namespace Interactuables.Interfaces
{
    public abstract class AInteractuable : MonoBehaviour, IInteractuable
    {
        protected PlayerStateController stateController;

        public EventHandler<String[]> SendMessageHandler;
        [TextArea(3, 10)] [SerializeField] protected String[] dialogue;
        protected GameObject colGO;

        private GameManager gameManager;

        protected LocalizationManager localization;

        private void Awake()
        {
            stateController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateController>();
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManager.RegisterInteractuable(this.gameObject);

            localization = new LocalizationManager();
        }

        //Si personaje entra en zona para interactuar
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player") && stateController.GetState().GetName() == "State_Explore")
            {
                colGO = col.gameObject;
                gameManager.ChangeInteractUI(new Vector3(1f, 1f, 1f));
                gameManager.activeInteractuable = this;
            }
        }

        //Si personaje sale de zona para interactuar (IMPORTANTE: No debe haber varias zonas trigger sobrepuestas)
        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                gameManager.ChangeInteractUI(new Vector3(0f, 0f, 1f));
                gameManager.activeInteractuable = null;
            }
        }

        public abstract void Interact();
    }
}
