using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes.Interfaces
{
    public abstract class AConcreteScene : IScene
    {
        protected ISceneState sceneState;
        protected bool finished = false;

        public AConcreteScene(ISceneState sceneState)
        {
            this.sceneState = sceneState;
        }

        public abstract void Enter();

        public abstract void Exit();

        public abstract void Update();

        public bool IsSceneFinished()
        {
            return finished;
        }
    }
}
