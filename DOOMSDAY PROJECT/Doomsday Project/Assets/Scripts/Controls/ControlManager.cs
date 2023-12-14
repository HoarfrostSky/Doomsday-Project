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
using Sounds;
using Game;

namespace Controls
{
    public class ControlManager : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float swordWeight;

        public bool canAttack = true;

        public Sprite[] spacebarSprites;
        public GameObject spacebar;

        public EventHandler<int> CameraHandler;

        public GameManager gameManager;

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
                spacebar.transform.localScale = new Vector3(0.4f, 0.4f, 1f);
                sword.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

                if (Input.GetKeyDown(KeyCode.Space) && canAttack)
                {
                    //If the attack is charged enough

                    player.GetComponent<Animator>().SetTrigger("Attack1");
                    sword.transform.localScale = new Vector3(0f, 0f, 1f);

                    canAttack = false;
                }

                if (Input.GetKey(KeyCode.Space))
                {
                    spacebar.GetComponent<SpriteRenderer>().sprite = spacebarSprites[1];
                }

                if (Input.GetKeyUp(KeyCode.Space))
                {
                    spacebar.GetComponent<SpriteRenderer>().sprite = null;
                }
            }
            else
            {
                spacebar.transform.localScale = new Vector3(0f, 0f, 1f);
                sword.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.7f, 0.7f, 1f);
            }
        }

        public void ResetSpacebar()
        {
            spacebar.GetComponent<SpriteRenderer>().sprite = spacebarSprites[0];
        }

        public void DialogueControls(State_Dialogue currentState, IPlayerState playerStateController, DialogueManager dialogueManager, DialogueUI dialogueUI, ManageEmpathise manageEmpathise)
        {
            GetComponent<Animator>().SetFloat("playerMovement", 0);

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

        public void ExploreControls(State_Explore currentState, IPlayerState playerStateController, Rigidbody2D rb, Animator playerAnim)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                GetComponent<PlayerSound>().PlaySoundPasos();
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                GetComponent<PlayerSound>().PlaySoundPasos();
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb.isKinematic = false;
                rb.AddForce(Vector2.left * speed * Time.deltaTime * 100, ForceMode2D.Force);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb.isKinematic = false;
                rb.AddForce(Vector2.right * speed * Time.deltaTime * 100, ForceMode2D.Force);
            }

            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                GetComponent<PlayerSound>().StopSoundPasos();
            }

            if (Input.GetKeyDown(KeyCode.E) && gameManager.activeInteractuable != null)
            {
                Debug.Log("He interactuado con: " + gameManager.activeInteractuable.ToString());
                gameManager.activeInteractuable?.Interact();
            }

            GetComponent<Animator>().SetFloat("playerMovement", rb.velocity.x);

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovementManager>().RegisterPlayerMovement();
        }

        public void JudgeControls(State_Judge currentState, IPlayerState playerStateController)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                playerStateController.SetState(new State_Save(playerStateController));
                CameraHandler?.Invoke(this, 4);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                playerStateController.SetState(new State_Condemn(playerStateController));
                CameraHandler?.Invoke(this, 4);
            }
        }

        public void MemoryControls(State_Memory currentState, IPlayerState playerStateController)
        {

        }

        public void SaveControls(State_Save currentState, IPlayerState playerStateController, GameObject player)
        {
            spacebar.transform.localScale = new Vector3(0.4f, 0.4f, 1f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.GetComponent<Animator>().SetTrigger("SaveIdle");
            }

            if (Input.GetKey(KeyCode.Space))
            {
                currentState.AddSavePoint();
                spacebar.GetComponent<SpriteRenderer>().sprite = spacebarSprites[1];
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                player.GetComponent<Animator>().SetTrigger("RevertToIdle");
                spacebar.GetComponent<SpriteRenderer>().sprite = spacebarSprites[0];
            }
        }

        public void CinematicControls(State_Cinematic currentState, IPlayerState playerStateController)
        {

        }

        public void CameraChargeAttack()
        {
            CameraHandler?.Invoke(this, 5);
        }

        public void CameraDeliverAttack()
        {
            CameraHandler?.Invoke(this, 6);
        }

        public void CameraRecoverAttack()
        {
            CameraHandler?.Invoke(this, 7);
        }

        public void ActivateCanAttack()
        {
            canAttack = true;
        }
    }
}
