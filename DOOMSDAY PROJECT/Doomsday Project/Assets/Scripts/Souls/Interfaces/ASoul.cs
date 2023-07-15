using System.Collections;
using System.Collections.Generic;
using System;
using Dialogue;
using UnityEngine;
using States.Controllers;
using States.ConcreteStates;

namespace Souls.Interfaces
{
    public abstract class ASoul : MonoBehaviour, ISoul
    {
        public int id;
        public String[] dialogue;
        public float moveSpeed;
        protected bool interactuable = false;
        protected GameObject playerGO;

        public EventHandler<String[]> sendDialogueHandler;

        private void Awake()
        {
            playerGO = GameObject.FindGameObjectWithTag("Player");
            playerGO.GetComponent<DialogueManager>().ConnectSoul(this);
        }

        public int GetID()
        {
            return id;
        }

        public bool GetInteractuable()
        {
            return interactuable;
        }

        public void SendDialogue()
        {
            playerGO.GetComponent<PlayerStateController>().SetState(new State_Dialogue(playerGO.GetComponent<PlayerStateController>()));
            sendDialogueHandler?.Invoke(this, dialogue);
        }

        public void MoveToLocalPosition(Vector3 d)
        {
            StartCoroutine(MoveSoul(d));
        }

        IEnumerator MoveSoul(Vector3 destination)
        {
            float elapsed = 0;
            Vector3 startingPoint = transform.localPosition;
            while(this.transform.localPosition != destination)
            {
                this.transform.localPosition = Vector3.Lerp(startingPoint, destination, elapsed);
                elapsed += (0.01f * moveSpeed * Time.deltaTime);
                yield return null;
            }

            GetComponent<Animator>().SetTrigger("SoulTransition");
            yield return null;
        }
    }
}
