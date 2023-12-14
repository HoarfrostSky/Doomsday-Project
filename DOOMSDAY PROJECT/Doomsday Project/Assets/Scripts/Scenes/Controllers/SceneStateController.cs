using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scenes.Interfaces;
using Scenes.ConcreteScenes;

namespace Scenes.Controllers
{
    public class SceneStateController : MonoBehaviour, ISceneState
    {
        private IScene currentSceneState;
        private IScene previousSceneState;

        public string language;

        private void Awake()
        {
            Object.DontDestroyOnLoad(this.gameObject);
            SetSceneState(new Scene_Menu(this));
        }

        public IScene GetSceneState()
        {
            return currentSceneState;
        }

        public IScene GetPreviousSceneState()
        {
            return previousSceneState;
        }

        public void SetSceneState(IScene sceneState)
        {
            if (currentSceneState != null)
            {
                currentSceneState.Exit();
            }

            previousSceneState = currentSceneState;
            currentSceneState = sceneState;
            sceneState.Enter();
        }

        public string GetLanguage()
        {
            return language;
        }
        public void SetLanguage(string newLanguage)
        {
            this.language = newLanguage;
        }

        private void Update()
        {
            currentSceneState.Update();
        }
    }
}
