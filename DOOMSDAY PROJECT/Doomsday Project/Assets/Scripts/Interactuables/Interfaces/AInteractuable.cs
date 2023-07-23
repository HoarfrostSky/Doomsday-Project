using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Dialogue;
using States.Controllers;
using Interact = Interactuables.Interfaces.IInteractuable;

namespace Interactuables.Interfaces
{
    public abstract class AInteractuable : MonoBehaviour, IInteractuable
    {
        protected PlayerStateController stateController;

        public EventHandler<String[]> SendMessageHandler;
        public EventHandler<IInteractuable> InteractorHandler;
        [SerializeField] protected String[] dialogue;
        protected GameObject colGO;

        private void Awake()
        {
            stateController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateController>();
            if(stateController.GetState() != null) stateController.GetState().RegisterInteractor(this.gameObject);
        }

        //If player enters range
        private void OnTriggerEnter2D(Collider2D col)
        {

            if (col.gameObject.CompareTag("Player"))
            {
                colGO = col.gameObject;
                GameObject.FindGameObjectWithTag("ShowInteract").transform.localScale = new Vector3(1f, 1f, 1f);
                InteractorHandler?.Invoke(this, this);
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                colGO = col.gameObject;
                GameObject.FindGameObjectWithTag("ShowInteract").transform.localScale = new Vector3(0f, 0f, 1f);
            }
        }

        public abstract void Interact();
    }
}
