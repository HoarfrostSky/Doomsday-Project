using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scenes.Interfaces;
using Scenes.Controllers;
using UnityEngine.SceneManagement;
using MainMenu;

namespace Scenes.ConcreteScenes
{
    public class Scene_Menu : AConcreteScene
    {
        private PlayButtonScript playButton;
        public Scene_Menu(ISceneState sceneState) : base(sceneState)
        {

        }

        public override void Enter()
        {
            Debug.Log("Entering Menu Scene");
            if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(1))
            {
                SceneManager.LoadScene("MenuScene");
            }

            playButton = GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButtonScript>();
            playButton.ConnectSceneController(sceneState);
        }
        public override void Exit()
        {
            Debug.Log("Exiting Menu Scene");

        }
        public override void Update()
        {

        }
    }
}