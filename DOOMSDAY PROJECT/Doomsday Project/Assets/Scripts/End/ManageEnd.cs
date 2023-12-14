using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Music;
using Scenes.ConcreteScenes;
using Scenes.Controllers;
using Localization;
using UnityEngine.SceneManagement;

namespace End
{
    public class ManageEnd : MonoBehaviour
    {
        public GameObject dialogueBackground;
        public GameObject lastJudgement;
        //public String[] endTexts;
        public GameObject condemnOrder;
        public GameObject finalText;
        public TextAsset finalTextData;
        private Dictionary<int, String> endTexts = new Dictionary<int, string>();
        private ManageMusicEnd music;
        private TextMeshPro textComponent;
        private int textPointer = -1;

        private bool isLastJudgement = false;

        private bool isIdle1 = false;
        private bool isIdle2 = false;
        private bool isIdle3 = false;

        private LocalizationManager localizationManager;

        private void Awake()
        {
            localizationManager = new LocalizationManager();
            localizationManager.LoadLocalizationString(FindObjectOfType<SceneStateController>()?.GetLanguage(), finalTextData, endTexts);

            music = GetComponent<ManageMusicEnd>();
            music.StartMusic(1);
            textComponent = dialogueBackground.GetComponentInChildren<TextMeshPro>();
            StartCoroutine(ManageEndSequence());
        }

        IEnumerator ManageEndSequence()
        {
            music.ManageVolumeLayer(0, 0, 100, 200);

            yield return new WaitForSeconds(4f);
            ShowDialogueBackground();
            NextText(); //. . .
            yield return new WaitForSeconds(3f);
            NextText(); //Doomsday arrived
            yield return new WaitForSeconds(5f);
            NextText(); //God did not
            yield return new WaitForSeconds(4f);
            NextText(); //I wonder why
            yield return new WaitForSeconds(4f);
            NextText(); //Maybe he felt shame
            yield return new WaitForSeconds(4f);
            NextText(); //Maybe he did not dare to face his own mistake
            yield return new WaitForSeconds(6f);
            NextText(); //Maybe he just forgot
            yield return new WaitForSeconds(5f);
            NextText(); //. . .
            yield return new WaitForSeconds(3f);
            NextText(); //This cannot continue
            yield return new WaitForSeconds(5f);
            NextText(); //Not like this
            yield return new WaitForSeconds(4f);
            NextText(); //Not me
            yield return new WaitForSeconds(4f);
            NextText(); //I've had enough
            yield return new WaitForSeconds(4f);
            NextText(); //This is the end
            yield return new WaitForSeconds(4f);
            NextText(); //It is time for my sins to be judged

            yield return new WaitForSeconds(6f);
            music.ManageVolumeLayer(1, 0, 100, 200);
            GetComponent<Animator>().SetTrigger("Darks");
            NextText(); //Not so fast, Nameless One
            yield return new WaitForSeconds(5f);
            NextText(); //What was it? The screaming door, perhaps?
            yield return new WaitForSeconds(6f);
            NextText(); //The quiet choir of solitude?

            yield return new WaitForSeconds(5f);
            GetComponent<Animator>().SetTrigger("Nameless");
            NextText(); //Their words
            yield return new WaitForSeconds(4f);
            NextText(); //They echo endlessly across these halls, ignorant of the fate of those who spoke them

            yield return new WaitForSeconds(8f);
            GetComponent<Animator>().SetTrigger("Darks");
            NextText(); //Emotions are eternal, Nameless One
            yield return new WaitForSeconds(5f);
            NextText(); //You cannot escape them

            yield return new WaitForSeconds(5f);
            GetComponent<Animator>().SetTrigger("Nameless");
            NextText(); //No
            yield return new WaitForSeconds(3f);
            NextText(); //But I can't bear this any longer
            yield return new WaitForSeconds(5f);
            NextText(); //One last judgement

            yield return new WaitForSeconds(4f);
            GetComponent<Animator>().SetTrigger("Darks");
            NextText(); //. . .
            yield return new WaitForSeconds(3f);
            NextText(); //There are still too many souls left
            yield return new WaitForSeconds(5f);
            NextText(); //You are the last one alive, the one who shall judge them
            yield return new WaitForSeconds(6f);
            NextText(); //If the judgement ends here, all of the remaining souls will be condemned
            yield return new WaitForSeconds(6f);
            NextText(); //Only by staying here you can save them, accordingly to what they deserve
            yield return new WaitForSeconds(6f);
            NextText(); //Is that not the right thing to do?

            yield return new WaitForSeconds(5f);
            GetComponent<Animator>().SetTrigger("Nameless");
            NextText(); //. . .

            yield return new WaitForSeconds(5f);
            HideDialogueBackground();
            GetComponent<Animator>().SetTrigger("LastJudge");
            lastJudgement.transform.localScale = new Vector3(1f, 1f, 1f);
            isLastJudgement = true;
            music.ManageVolumeLayer(0, 100, 0, 200);
            music.ManageVolumeLayer(1, 100, 0, 200);
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
                    lastJudgement.transform.localScale = new Vector3(0f, 0f, 1f);
                    GetComponent<Animator>().SetTrigger("Save");
                    //Save
                }
                else if (Input.GetKeyDown(KeyCode.E))
                {
                    //Condemn
                    lastJudgement.transform.localScale = new Vector3(0f, 0f, 1f);
                    GetComponent<Animator>().SetTrigger("Attack1");
                }
            }
            if(isIdle1)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GetComponent<Animator>().SetTrigger("Attack2");
                }
            }
            if (isIdle2)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GetComponent<Animator>().SetTrigger("Attack3");
                }
            }
            if (isIdle3)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GetComponent<Animator>().SetTrigger("Attack4");
                }
            }
        }

        public void SetIdle1()
        {
            isIdle1 = true;
            condemnOrder.GetComponent<TextMeshPro>().fontSize = 10f;
            condemnOrder.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        public void SetIdle2()
        {
            isIdle2 = true;
            condemnOrder.GetComponent<TextMeshPro>().fontSize = 50f;
            condemnOrder.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        public void SetIdle3()
        {
            isIdle3 = true;
            condemnOrder.GetComponent<TextMeshPro>().fontSize = 110f;
            condemnOrder.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        public void HideOrder()
        {
            condemnOrder.transform.localScale = new Vector3(0f, 0f, 1f);
        }

        public void EndMusic()
        {
            finalText.transform.localScale = new Vector3(1f, 1f, 0f);
            music.ManageVolumeLayer(0, 100, 0, 150);
            music.ManageVolumeLayer(1, 100, 0, 150);
        }

        public void ReturnToMenu()
        {
            if(FindObjectOfType<SceneStateController>().gameObject != null) Destroy(FindObjectOfType<SceneStateController>().gameObject);
            SceneManager.LoadScene("MenuScene");
            //Application.Quit();
        }
    }
}
