using Interactuables.Interfaces;
using States.Controllers;
using States.ConcreteStates;
using System;
using Souls;
using UnityEngine;
using CameraNamespace;

namespace Interactuables.ConcreteInteractuables
{
    public class Interactuable_Throne : AInteractuable
    {
        public GameObject player;
        public GameObject cameraGO;
        private bool canSpawnSoul = true;

        public EventHandler<int> CameraHandler;

        public override void Interact()
        { 
            //colGO.GetComponent<PlayerStateController>().SetState(new State_Dialogue(colGO.GetComponent<PlayerStateController>()));
            //SendMessageHandler?.Invoke(this, dialogue);

            if (canSpawnSoul)
            {
                CameraHandler?.Invoke(this, 1);

                GameObject.FindGameObjectWithTag("SoulSpawner").GetComponent<SoulSpawner>().SpawnSoul();
                GetComponent<Collider2D>().enabled = false;
                canSpawnSoul = false;

                player.GetComponent<Animator>().SetTrigger("SitLeft");
                player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                player.transform.position = new Vector3(-2.98f, 0.39f, -2f);
            }
        }

        public void SetCanSpawnSoul(bool b)
        {
            if (b) GetComponent<Collider2D>().enabled = true;
            else GetComponent<Collider2D>().enabled = false;

            this.canSpawnSoul = b;
        }

        private void Update()
        {
            if(canSpawnSoul)
            {
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.7f, 0.7f, 1f);
            }
        }
    }
}
