using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scenes.Interfaces;
using Scenes.Controllers;
using UnityEngine.SceneManagement;

namespace Scenes.ConcreteScenes
{
    public class Scene_End : AConcreteScene
    {
        public Scene_End(ISceneState sceneState) : base(sceneState)
        {

        }

        public override void Enter()
        {
            Debug.Log("Entering End Scene");

            SceneManager.LoadScene("EndScene");
        }
        public override void Exit()
        {
            Debug.Log("Exiting End Scene");

        }
        public override void Update()
        {

        }
    }
}