using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

namespace End
{
    public class ManageEnd : MonoBehaviour
    {
        public GameObject dialogueBackground;
        public GameObject lastJudgement;
        public String[] endTexts;

        private TextMeshPro textComponent;
        private int textPointer = -1;

        private bool isLastJudgement = false;

        private void Awake()
        {
            textComponent = dialogueBackground.GetComponentInChildren<TextMeshPro>();
            StartCoroutine(ManageEndSequence());
        }

        IEnumerator ManageEndSequence()
        {
            yield return new WaitForSeconds(2f);
            ShowDialogueBackground();
            NextText(); //. . .
            yield return new WaitForSeconds(3f);
            NextText(); //Doomsday arrived
            yield return new WaitForSeconds(4f);
            NextText(); //God did not
            yield return new WaitForSeconds(4f);
            NextText(); //I wonder why
            yield return new WaitForSeconds(4f);
            NextText(); //Maybe he felt shame
            yield return new WaitForSeconds(4f);
            NextText(); //Maybe he did not dare to face his own mistake
            yield return new WaitForSeconds(5f);
            NextText(); //Maybe he just forgot
            yield return new WaitForSeconds(4f);
            NextText(); //. . .
            yield return new WaitForSeconds(3f);
            NextText(); //This cannot continue
            yield return new WaitForSeconds(4f);
            NextText(); //Not like this
            yield return new WaitForSeconds(4f);
            NextText(); //Not me
            yield return new WaitForSeconds(4f);
            NextText(); //I've had enough
            yield return new WaitForSeconds(4f);
            NextText(); //This is the end
            yield return new WaitForSeconds(4f);
            NextText(); //It is time for my sins to be judged

            yield return new WaitForSeconds(4f);
            GetComponent<Animator>().SetTrigger("Darks");
            NextText(); //Not so fast, Nameless One
            yield return new WaitForSeconds(4f);
            NextText(); //What was it? The screaming door, perhaps?
            yield return new WaitForSeconds(4f);
            NextText(); //The quiet choir of solitude?

            yield return new WaitForSeconds(4f);
            GetComponent<Animator>().SetTrigger("Nameless");
            NextText(); //Their words
            yield return new WaitForSeconds(4f);
            NextText(); //They echo endlessly across these halls, ignorant of the fate of those who spoke them

            yield return new WaitForSeconds(6f);
            GetComponent<Animator>().SetTrigger("Darks");
            NextText(); //Emotions are eternal, Nameless One
            yield return new WaitForSeconds(4f);
            NextText(); //You cannot escape them

            yield return new WaitForSeconds(4f);
            GetComponent<Animator>().SetTrigger("Nameless");
            NextText(); //No
            yield return new WaitForSeconds(3f);
            NextText(); //But I can't bear this any longer
            yield return new WaitForSeconds(4f);
            NextText(); //One last judgement

            yield return new WaitForSeconds(4f);
            GetComponent<Animator>().SetTrigger("Darks");
            NextText(); //. . .
            yield return new WaitForSeconds(3f);
            NextText(); //There are still too many souls left
            yield return new WaitForSeconds(4f);
            NextText(); //You are the last one alive, the one who shall judge them
            yield return new WaitForSeconds(4f);
            NextText(); //If the judgement ends here, all of the remaining souls will be condemned
            yield return new WaitForSeconds(5f);
            NextText(); //Only by staying here you can save them, accordingly to what they deserve
            yield return new WaitForSeconds(5f);
            NextText(); //Is that not the right thing to do?

            yield return new WaitForSeconds(4f);
            GetComponent<Animator>().SetTrigger("Nameless");
            NextText(); //. . .

            yield return new WaitForSeconds(5f);
            HideDialogueBackground();
            GetComponent<Animator>().SetTrigger("LastJudge");
            lastJudgement.transform.localScale = new Vector3(1f, 1f, 1f);
            isLastJudgement = true;
        }

        private void ShowDialogueBackground()
        {
            dialogueBackground.transform.localScale = new Vector3(0.67f, 0.67f, 1f);
        }

        private void HideDialogueBackground()
        {
            dialogueBackground.transform.localScale = new Vector3(0f, 0f, 1f);
        }

        private void NextText()
        {
            textPointer++;
            textComponent.text = endTexts[textPointer];
        }

        private void Update()
        {
            if(isLastJudgement)
            {
                if(Input.GetKeyDown(KeyCode.Q))
                {
                    //Save
                }
                else if (Input.GetKeyDown(KeyCode.E))
                {
                    //Condemn
                    lastJudgement.transform.localScale = new Vector3(0f, 0f, 1f);
                    GetComponent<Animator>().SetTrigger("Attack1");
                }
            }
        }
    }
}
