using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Dialogue;
using Player;
using CameraNamespace;
using States.Interfaces;
using States.Controllers;
using States.ConcreteStates;
using Interactuables.Interfaces;
using Interact = Interactuables.Interfaces.IInteractuable;

namespace Controls
{
    public class ControlManager : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float swordWeight;

        public EventHandler<int> CameraHandler;

        public void CondemnControls(State_Condemn currentState, IPlayerState playerStateController, float angleCondemn, GameObject sword, GameObject player)
        {
            float angleAttack = -1 * angleCondemn / swordWeight;

            if (sword.transform.rotation.eulerAngles.z > 100 && sword.transform.rotation.eulerAngles.z < 180)
            {
                angleAttack = Mathf.Clamp(angleAttack, -1000f, 0f);
            }
            else if (sword.transform.rotation.eulerAngles.z < 290 && sword.transform.rotation.eulerAngles.z > 180)
            {
                angleAttack = Mathf.Clamp(angleAttack, 0f, 1000f);
            }

            if (Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.Mouse1))
            {
                sword.transform.RotateAround(this.gameObject.transform.position, Vector3.forward, angleAttack);
            }

            if (sword.transform.rotation.eulerAngles.z < 360 && sword.transform.rotation.eulerAngles.z > 180)
            {
                sword.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //If the attack is charged enough

                    player.GetComponent<Animator>().SetTrigger("Attack1");
                    sword.transform.localScale = new Vector3(0f, 0f, 1f);

                    Debug.Log("SOUL CONDEMNED");
                }
            }
            else
            {
                sword.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.7f, 0.7f, 1f);
            }

            /*if(Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("Se envía la orden");
                CameraHandler?.Invoke(this,0);
            }*/
        }

        public void DialogueControls(State_Dialogue currentState, IPlayerState playerStateController, DialogueManager dialogueManager, DialogueUI dialogueUI, ManageEmpathise manageEmpathise)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Insert))
            {
                if (dialogueUI.EstaMostrandoTexto())
                {
                    dialogueUI.Interrumpir();
                }
                else
                {
                    if (!manageEmpathise.CheckAvailability()) dialogueManager.NextMessage();
                }
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (manageEmpathise.CheckAvailability()) manageEmpathise.Empathise();
            }
        }

        public void ExploreControls(State_Explore currentState, IPlayerState playerStateController, IInteractuable interactor, Rigidbody2D rb, Animator playerAnim)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb.isKinematic = false;
                rb.AddForce(Vector2.left * speed * Time.deltaTime * 100, ForceMode2D.Force);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rb.isKinematic = false;
                rb.AddForce(Vector2.right * speed * Time.deltaTime * 100, ForceMode2D.Force);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                playerAnim.SetTrigger("WalkLeft");
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                playerAnim.SetTrigger("WalkRight");
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                playerAnim.SetTrigger("StopWalking");
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                playerAnim.SetTrigger("StopWalking");
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                interactor?.Interact();
            }

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovementManager>().RegisterPlayerMovement();
        }

        public void JudgeControls(State_Judge currentState, IPlayerState playerStateController)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                playerStateController.SetState(new State_Save(playerStateController));
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                playerStateController.SetState(new State_Condemn(playerStateController));
            }
        }

        public void MemoryControls(State_Memory currentState, IPlayerState playerStateController)
        {

        }

        public void SaveControls(State_Save currentState, IPlayerState playerStateController, GameObject player)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.GetComponent<Animator>().SetTrigger("SaveIdle");
            }

            if (Input.GetKey(KeyCode.Space))
            {
                currentState.AddSavePoint();
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                player.GetComponent<Animator>().SetTrigger("RevertToIdle");
            }
        }

        public void CinematicControls(State_Cinematic currentState, IPlayerState playerStateController)
        {

        }
    }
}
