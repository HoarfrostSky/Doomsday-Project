using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes.Interfaces
{
    public interface ISceneState
    {
        //State Management
        public void SetSceneState(IScene sceneState);
        public IScene GetSceneState();
        public IScene GetPreviousSceneState();
    }
}
