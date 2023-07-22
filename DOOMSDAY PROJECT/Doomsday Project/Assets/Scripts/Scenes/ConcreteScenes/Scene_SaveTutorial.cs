using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scenes.Interfaces;
using Scenes.Controllers;
using UnityEngine.SceneManagement;
using MainMenu;

namespace Scenes.ConcreteScenes
{
    public class Scene_SaveTutorial : AConcreteScene
    {
        private float savePoints = 0;
        private GameObject saveTutorialGO;
        private GameObject background;
        private SpriteRenderer backgroundRend;
        private Sprite[] controlSprites;

        public Scene_SaveTutorial(ISceneState sceneState, GameObject saveTutorialGO, GameObject background, Sprite[] controlSprites) : base(sceneState)
        {
            this.saveTutorialGO = saveTutorialGO;
            this.background = background;
            this.controlSprites = controlSprites;
        }

        public override void Enter()
        {
            Debug.Log("Entering Save Tutorial Scene");

            saveTutorialGO.transform.localScale = new Vector3(1f, 1f, 1f);
            backgroundRend = background.GetComponent<SpriteRenderer>();
        }
        public override void Exit()
        {
            Debug.Log("Exiting Save Tutorial Scene");

            saveTutorialGO.transform.localScale = new Vector3(0f, 0f, 1f);
        }
        public override void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                saveTutorialGO.GetComponentInChildren<SpriteRenderer>().sprite = controlSprites[1];
            }

            if (Input.GetKey(KeyCode.Space))
            {
                savePoints += 200 * Time.deltaTime;
                Debug.Log("Save Points: " + savePoints);

                backgroundRend.color = Color.Lerp(new Color(0f, 0f, 0f, 1f), new Color(1f, 1f, 1f, 1f), savePoints/1000f);
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                saveTutorialGO.GetComponentInChildren<SpriteRenderer>().sprite = controlSprites[0];
            }

            if(savePoints > 1000)
            {
                Debug.Log("ALMA SALVADA");

                finished = true;
            }
        }

    }
}