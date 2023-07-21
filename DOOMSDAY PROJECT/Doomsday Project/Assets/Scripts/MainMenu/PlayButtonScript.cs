using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Scenes.Interfaces;
using Scenes.Controllers;
using Scenes.ConcreteScenes;

namespace MainMenu
{
    public class PlayButtonScript : MonoBehaviour
    {
        private ISceneState sceneStateController;
        public EventHandler<AConcreteScene> sceneHandler;
        public GameObject introScreenManager;

        public void StartGame()
        {
            introScreenManager.GetComponent<ManageIntro>().StartIntro();
            //sceneStateController.SetSceneState(new Scene_MainScene(sceneStateController));
        }

        public void ConnectSceneController(ISceneState newSceneStateController)
        {
            this.sceneStateController = newSceneStateController;
        }
    }

}