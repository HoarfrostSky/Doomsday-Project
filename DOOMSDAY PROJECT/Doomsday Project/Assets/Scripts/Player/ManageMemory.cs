using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using States.Interfaces;
using States.ConcreteStates;
using Dialogue.Text3D;

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

        private int memoryPointer = -1;
        private bool finishedText = false;

        public EventHandler<String> dialogueHandler;

        public void RecieveMemoryData(IPlayerState stateControllerReference, Sprite[] memSprites, String[] memStrings, TextMeshPro textComp, SpriteRenderer spriteComp)
        {
            if (memSprites.Length == memStrings.Length)
            {
                this.playerStateController = stateControllerReference;

                this.currentMemorySprites = memSprites;
                this.currentMemoryDialogue = memStrings;
                this.memoryText = textComp;
                this.memorySprite = spriteComp;

                memoryText.gameObject.GetComponent<Dialogue3D>().isTextFinishedHandler += ChangeFinishedText;
                memoryText.gameObject.GetComponent<Dialogue3D>().ConnectDialogue(this);

                StartCoroutine(ExecuteMemory());
            }
            else
            {
                Debug.LogError("ERROR: NUMERO DE SPRITES Y NUMERO DE DIALOGO DE LA MEMORIA ACTUAL NO COINCIDEN. DEBEN COINCIDIR.");
            }
        }
        public void ChangeFinishedText(object sender, bool b)
        {
            this.finishedText = b;
        }
        IEnumerator ExecuteMemory()
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
        }
    }
}
