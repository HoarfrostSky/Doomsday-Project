using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scenes.Interfaces;
using Scenes.Controllers;
using UnityEngine.SceneManagement;
using MainMenu;

namespace Scenes.ConcreteScenes
{
    public class Scene_CondemnTutorial : AConcreteScene
    {
        private GameObject condemnTutorialGO;
        private GameObject sword;
        private GameObject spaceBarGO;

        private float mouseDeltaHPosition = 0;
        private float previousHPos = 0;


        public Scene_CondemnTutorial(ISceneState sceneState, GameObject condemnTutorialGO, GameObject spaceBarSpriteGO) : base(sceneState)
        {
            this.condemnTutorialGO = condemnTutorialGO;
            this.spaceBarGO = spaceBarSpriteGO;
        }

        public override void Enter()
        {
            Debug.Log("Entering Condemn Tutorial Scene");

            condemnTutorialGO.transform.localScale = new Vector3(1f, 1f, 1f);
            sword = GameObject.FindGameObjectWithTag("Sword");
        }
        public override void Exit()
        {
            Debug.Log("Exiting Condemn Tutorial Scene");

            condemnTutorialGO.transform.localScale = new Vector3(0f, 0f, 1f);
        }
        public override void Update()
        {
            float mouseHPos = Input.mousePosition.x;
            mouseDeltaHPosition = mouseHPos - previousHPos;
            previousHPos = mouseHPos;

            if (Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.Mouse1))
            {
                sword.transform.RotateAround(new Vector3(3.75f, -4f, 0f), Vector3.forward, -mouseDeltaHPosition/90);
            }
            if (sword.transform.rotation.eulerAngles.z < 360 && sword.transform.rotation.eulerAngles.z > 180)
            {
                spaceBarGO.transform.localScale = new Vector3(1f, 1f, 1f);
                sword.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //If the attack is charged enough

                    finished = true;
                    Debug.Log("SOUL CONDEMNED");
                }
            }
            else
            {
                spaceBarGO.transform.localScale = new Vector3(0f, 0f, 1f);
                sword.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.7f, 0.7f, 1f);
            }
        }
    }
}