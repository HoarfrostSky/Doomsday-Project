using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scenes.Controllers;
using Scenes.ConcreteScenes;

namespace PauseMenu
{
    public class ExitButtonScript : MonoBehaviour
    {
        public void ExitToMenu()
        {
            SceneStateController cont = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneStateController>();
            cont.SetSceneState(new Scene_Menu(cont));
        }
    }
}