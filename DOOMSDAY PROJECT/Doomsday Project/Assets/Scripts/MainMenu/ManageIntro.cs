using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Music;
using TMPro;
using MainMenu;
using Scenes.Interfaces;
using Scenes.ConcreteScenes;
using Scenes.Controllers;

namespace MainMenu
{
    public class ManageIntro : MonoBehaviour
    {
        public GameObject introMusicManager;
        public GameObject menuGameObject;
        public GameObject saveTutorial;
        public GameObject condemnTutorial;
        public GameObject sceneManager;
        public Sprite[] spaceBarSprites;
        public GameObject spaceBarGO;
        public GameObject introAnimationGO;

        private ManageMusicIntroduction introMusic;
        private TextMeshPro textComponent;
        private SpriteRenderer spriteComponent;

        public float timeOffset;

        public String[] introTexts;
        private int textPointer = -1;

        public void StartIntro()
        {
            Debug.Log("Se llama a StartIntro en ManageIntro script");

            introMusic = introMusicManager.GetComponent<ManageMusicIntroduction>();
            textComponent = GetComponentInChildren<TextMeshPro>();
            spriteComponent = GetComponent<SpriteRenderer>();

            StartCoroutine(ManageIntroSequence());
        }

        IEnumerator ManageIntroSequence()
        {
            sceneManager.GetComponent<SceneStateController>().GetSceneState().Exit();
            Debug.Log("Comienza la intro");

            introMusic.StartMusic(1);
            introMusic.ManageVolumeLayer(0, 0, 100, 1000);

            yield return new WaitForSeconds(timeOffset);

            HideMenu();
            ChangeTextSize(4.58f);
            NextText(); //Doomsday arrived
            ShowScreen();

            yield return new WaitForSeconds(5f);

            ChangeBackgroundColor(new Color(1f, 1f, 1f, 1f));
            ChangeTextColor(new Color(0f, 0f, 0f, 1f));
            ChangeTextSize(0.6f);
            NextText(); //God did not

            yield return new WaitForSeconds(5f);

            ChangeBackgroundColor(new Color(0f, 0f, 0f, 1f));
            ChangeTextColor(new Color(1f, 1f, 1f, 1f));
            NextText(); //

            yield return new WaitForSeconds(4f);

            ChangeTextSize(1.24f);
            NextText(); //You have been chosen...

            yield return new WaitForSeconds(6f);

            NextText(); //Nameless One

            yield return new WaitForSeconds(5f);

            NextText(); //Souls will be granted passage...

            yield return new WaitForSeconds(6f);

            NextText(); //

            yield return new WaitForSeconds(2f);

            NextText(); //You will judge them


            yield return new WaitUntil(() => !introMusic.IsLayerPlaying(0));

            introMusic.StartMusic(2);
            introMusic.ManageVolumeLayer(0, 0, 70, 40);
            introMusic.ManageVolumeLayer(1, 0, 70, 40);
            introMusic.ManageVolumeLayer(2, 0, 70, 40);
            NextText(); //

            yield return new WaitForSeconds(1f);

            ChangeTextPosition(new Vector3(0f, 0.18f, -0.5f));
            NextText(); //You will save them
            sceneManager.GetComponent<SceneStateController>().SetSceneState(new Scene_SaveTutorial(sceneManager.GetComponent<SceneStateController>(), saveTutorial, this.gameObject, spaceBarSprites));

            yield return new WaitUntil(() => sceneManager.GetComponent<SceneStateController>().GetSceneState().IsSceneFinished());

            Debug.Log("Escena terminada");

            NextText(); //You will condemn them
            ChangeBackgroundColor(new Color(0f, 0f, 0f, 1f));
            sceneManager.GetComponent<SceneStateController>().SetSceneState(new Scene_CondemnTutorial(sceneManager.GetComponent<SceneStateController>(), condemnTutorial, spaceBarGO));

            yield return new WaitUntil(() => sceneManager.GetComponent<SceneStateController>().GetSceneState().IsSceneFinished());

            sceneManager.GetComponent<SceneStateController>().GetSceneState().Exit();
            introMusic.ManageVolumeLayer(0, 70, 0, 200);
            introMusic.ManageVolumeLayer(1, 70, 0, 200);
            introMusic.ManageVolumeLayer(2, 70, 0, 200);
            NextText(); //

            yield return new WaitForSeconds(2f);

            ChangeTextPosition(new Vector3(0f, 0f, -0.5f));
            NextText(); //Make haste, Nameless One

            yield return new WaitForSeconds(2f);

            NextText(); //

            yield return new WaitForSeconds(1f);

            introAnimationGO.GetComponent<Animator>().SetTrigger("StartIntroAnimation");

            IntroductionAlert alertScript = introAnimationGO.GetComponent<IntroductionAlert>();
            yield return new WaitUntil(() => alertScript.GetFinished());

            ChangeTextSize(1f);
            ChangeTextPosition(new Vector3(0.34f, -0.2f, -0.5f));
            NextText(); //Loading

            sceneManager.GetComponent<SceneStateController>().SetSceneState(new Scene_MainScene(sceneManager.GetComponent<SceneStateController>()));

            Debug.Log("Escena terminada");

            yield return null;
        }

        private void ShowScreen()
        {
            transform.localScale = new Vector3(20f, 20f, 1f);
        }
        private void HideScreen()
        {
            transform.localScale = new Vector3(0f, 0f, 1f);
        }

        private void NextText()
        {
            textPointer++;
            textComponent.text = introTexts[textPointer];
        }

        private void ChangeTextSize(float newSize)
        {
            textComponent.fontSize = newSize;
        }

        private void ChangeTextPosition(Vector3 newPosition)
        {
            textComponent.transform.localPosition = newPosition;
        }

        private void ChangeBackgroundColor(Color newColor)
        {
            spriteComponent.color = newColor;
        }

        private void ChangeTextColor(Color newColor)
        {
            textComponent.color = newColor;
        }

        private void HideMenu()
        {
            menuGameObject.GetComponent<RectTransform>().localScale = new Vector3(0f, 0f, 1f);
        }
    }
}