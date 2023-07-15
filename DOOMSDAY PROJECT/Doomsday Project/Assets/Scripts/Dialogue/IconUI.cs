using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Dialogue
{
    public class IconUI : MonoBehaviour
    {
        public String[] nameList;
        public Sprite[] iconList;

        private Sprite currentIcon;
        private DialogueManager dialogueManager;

        private Dictionary<String, Sprite> iconDictionary = new Dictionary<String, Sprite>() { };

        private void Awake()
        {
            if(nameList.Length == iconList.Length)
            {
                for(int i = 0; i < nameList.Length; i++)
                {
                    iconDictionary.Add(nameList[i], iconList[i]);
                }
            }
            else
            {
                Debug.LogError("ERROR: No coincide longitud de nombres con iconos");
            }
        }

        public void RecieveIcon(object sender, String name)
        {
            currentIcon = iconDictionary[name];
            GetComponent<Image>().sprite = currentIcon;
        }

        public void ConnectDialogue(DialogueManager d)
        {
            this.dialogueManager = d;
            dialogueManager.iconHandler += RecieveIcon;
        }
    }
}
