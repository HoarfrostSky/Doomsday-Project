using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactuables.Interfaces;
using Dialogue;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        private List<GameObject> interactuableList = new List<GameObject>();
        public IInteractuable activeInteractuable;
        public GameObject player;
        public GameObject interactUI;

        public DialogueManager dialogueManager;

        private int currentSaves = 0;
        private int currentCondemns = 0;

        //Interactuable llama a esta función para registrarse en la lista de gameObjects interactuables
        public void RegisterInteractuable(GameObject newInteractor)
        {
            dialogueManager.RegisterMessageHandler(newInteractor);
            interactuableList.Add(newInteractor);
        }

        public void ChangeInteractUI(Vector3 size)
        {
            interactUI.transform.localScale = size;
        }

        public void AddSave()
        {
            currentSaves++;
        }

        public void AddCondemn()
        {
            currentCondemns++;
        }
    }
}
