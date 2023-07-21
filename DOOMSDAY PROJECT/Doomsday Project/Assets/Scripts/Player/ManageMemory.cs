using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using States.Interfaces;
using States.ConcreteStates;
using Dialogue.Text3D;
using CameraNamespace;

namespace Player
{
    public class ManageMemory : MonoBehaviour
    {
        private IPlayerState playerStateController;

        private Sprite[] currentMemorySprites;
        private Sprite currentSprite;
        private String[] currentMemoryDialogue;
        private String currentDialogue;
        private TextMeshPro memoryText;
        private SpriteRenderer memorySprite;
        public float cameraSize;
        public float endCameraSize;

        //private int memorySpritePointer = -1;
        private int memoryDialoguePointer = -1;
        private bool finishedText = false;

        public EventHandler<String> dialogueHandler;

        public void RecieveMemoryData(IPlayerState stateControllerReference, String[] memStrings, TextMeshPro textComp, SpriteRenderer spriteComp)
        {
                this.playerStateController = stateControllerReference;

                //this.currentMemorySprites = memSprites;
                this.currentMemoryDialogue = memStrings;
                this.memoryText = textComp;
                this.memorySprite = spriteComp;

                memoryText.gameObject.GetComponent<Dialogue3D>().isTextFinishedHandler += ChangeFinishedText;
                memoryText.gameObject.GetComponent<Dialogue3D>().ConnectDialogue(this);

            //StartCoroutine(ExecuteMemory());
            memoryDialoguePointer++;

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize = cameraSize;

            for(int i = 0; i < 9; i++)
            {
                GetComponent<Animator>().SetLayerWeight(i, 0);
            }

                switch (memStrings[memoryDialoguePointer])
            {
                case "Harn":
                    GetComponent<Animator>().SetLayerWeight(1, 1);
                    GetComponent<Animator>().SetTrigger("StartMemoryHarn");
                    break;
                case "Strange":
                    GetComponent<Animator>().SetLayerWeight(2, 1);
                    GetComponent<Animator>().SetTrigger("StartMemoryStrange");
                    break;
                case "Bretta":
                    GetComponent<Animator>().SetLayerWeight(4, 1);
                    GetComponent<Animator>().SetTrigger("StartMemoryBretta");
                    break;
                case "Hayure":
                    GetComponent<Animator>().SetLayerWeight(5, 1);
                    GetComponent<Animator>().SetTrigger("StartMemoryHayure");
                    break;
                case "Colin":
                    GetComponent<Animator>().SetLayerWeight(6, 1);
                    GetComponent<Animator>().SetTrigger("StartMemoryColin");
                    break;
                case "Lenna":
                    GetComponent<Animator>().SetLayerWeight(8, 1);
                    GetComponent<Animator>().SetTrigger("StartMemoryLenna");
                    break;
                default:
                    Debug.LogError("ERROR: Memory no encontrado");
                    break;

            }

        }
        public void ChangeFinishedText(object sender, bool b)
        {
            this.finishedText = b;
        }

        public void NextMemoryText()
        {
            this.memoryDialoguePointer++;
            currentDialogue = currentMemoryDialogue[memoryDialoguePointer];
            dialogueHandler?.Invoke(this, currentDialogue);
        }

        public void EmptyMemoryText()
        {
            currentDialogue = "";
            dialogueHandler?.Invoke(this, currentDialogue);
        }

        public void ReturnToDialogue()
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize = endCameraSize;
            playerStateController.SetState(new State_Dialogue(playerStateController));
        }

        /*public void NextMemorySprite()
        {
            this.memorySpritePointer++;
            currentSprite = currentMemorySprites[memorySpritePointer];
            memorySprite.sprite = currentSprite;
        }*/

        /*IEnumerator ExecuteMemory()
        {
            while (memoryPointer < currentMemorySprites.Length - 1)
            {
                memoryPointer++;
                currentSprite = currentMemorySprites[memoryPointer];
                currentDialogue = currentMemoryDialogue[memoryPointer];

                memorySprite.sprite = currentSprite;
                dialogueHandler?.Invoke(this, currentDialogue);

                yield return null;

                //Se espera a que el texto se haya mostrado
                yield return new WaitUntil(() => finishedText);
                yield return new WaitForSeconds(3);
            }

            playerStateController.SetState(new State_Dialogue(playerStateController));

            yield return null;
        }*/
    }
}
