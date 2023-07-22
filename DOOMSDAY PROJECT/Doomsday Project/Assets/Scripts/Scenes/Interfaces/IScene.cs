using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes.Interfaces
{
    public interface IScene
    {
        public void Enter();
        public void Exit();
        public void Update();
        public bool IsSceneFinished();
    }
}
