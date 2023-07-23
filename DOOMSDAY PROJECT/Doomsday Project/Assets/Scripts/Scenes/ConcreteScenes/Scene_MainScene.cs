using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scenes.Interfaces;
using Scenes.Controllers;
using UnityEngine.SceneManagement;
using PauseMenu;
using Sounds;

namespace Scenes.ConcreteScenes
{
    public class Scene_MainScene : AConcreteScene
    {
        private bool pause = false;
        private GameObject pauseMenuGO;

        public Scene_MainScene(ISceneState sceneState) : base(sceneState)
        {

        }

        public override void Enter()
        {
            Debug.Log("Entering Main Scene");
            SceneManager.LoadScene("MainScene");
        }
        public override void Exit()
        {
            Debug.Log("Exiting Main Scene");

        }
        public override void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenuGO = GameObject.Find("PauseMenu");
                pauseMenuGO.GetComponentInChildren<ResumeButtonScript>().ConnectScene(this);
                if (pause)
                {
                    //Cerrar
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSound>().PlayCerrarPausa();
                    pauseMenuGO.transform.localScale = new Vector3(0f, 0f, 1f);
                    pause = false;
                }
                else
                {
                    //Abrir
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSound>().PlayAbrirPausa();
                    pauseMenuGO.transform.localScale = new Vector3(1f, 1f, 1f);
                    pause = true;
                }
            }

        }

        public void SetPause(bool b)
        {
            this.pause = b;
        }
    }
}