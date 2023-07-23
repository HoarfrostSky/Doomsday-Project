using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Scenes.Interfaces;
using Scenes.Controllers;
using Scenes.ConcreteScenes;
using UnityEngine.UI;
using TMPro;

namespace MainMenu
{
    public class PlayButtonScript : MonoBehaviour
    {
        private ISceneState sceneStateController;
        public EventHandler<AConcreteScene> sceneHandler;
        public GameObject introScreenManager;
        public GameObject quitButton;
        public Sprite buttonPressed;

        private bool inIntro = false;

        public void StartGame()
        {
            if (!inIntro)
            {
                inIntro = true;
                GetComponent<Image>().sprite = buttonPressed;
                GetComponentInChildren<TextMeshProUGUI>().fontSize = 0f;
                quitButton.GetComponent<Image>().gameObject.GetComponent<RectTransform>().localScale = new Vector3(0f, 0f, 1f);
                introScreenManager.GetComponent<ManageIntro>().StartIntro();
            }
            //sceneStateController.SetSceneState(new Scene_MainScene(sceneStateController));
        }

        public void ConnectSceneController(ISceneState newSceneStateController)
        {
            this.sceneStateController = newSceneStateController;
        }
    }

}