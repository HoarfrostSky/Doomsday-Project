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
            //Esto no deberia estad comentado pero son las 2 de la mañana y estoy hasta la polla
            /*Debug.Log("Entering Menu Scene");
            if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0))
            {
                SceneManager.LoadScene("MenuScene");
            }*/

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