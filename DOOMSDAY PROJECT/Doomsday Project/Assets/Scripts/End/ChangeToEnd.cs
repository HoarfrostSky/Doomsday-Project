using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scenes.Controllers;
using Scenes.ConcreteScenes;

namespace End
{
    public class ChangeToEnd : MonoBehaviour
    {
        public void End()
        {
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneStateController>().SetSceneState(new Scene_End(GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneStateController>()));
        }
    }
}
