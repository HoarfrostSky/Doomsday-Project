using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scenes.Interfaces;
using Scenes.Controllers;
using UnityEngine.SceneManagement;

namespace Scenes.ConcreteScenes
{
    public class Scene_Tutorial : AConcreteScene
    {
        public Scene_Tutorial(ISceneState sceneState) : base(sceneState)
        {

        }

        public override void Enter()
        {
            Debug.Log("Entering Main Scene");

            SceneManager.LoadScene("TutorialScene");
        }
        public override void Exit()
        {
            Debug.Log("Exiting Main Scene");

        }
        public override void Update()
        {

        }
    }
}