using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scenes.ConcreteScenes;

namespace PauseMenu
{
    public class ResumeButtonScript : MonoBehaviour
    {
        private Scene_MainScene scene;
        public void ResumeGame()
        {
            GameObject.FindGameObjectWithTag("PauseMenu").transform.localScale = new Vector3(0f, 0f, 1f);
            scene.SetPause(false);
        }

        public void ConnectScene(Scene_MainScene scene)
        {
            this.scene = scene;
        }
    }
}