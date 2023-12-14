using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Dialogue
{
    public class IconUI : MonoBehaviour
    {
        public String[] nameList;
        public Sprite[] iconList;
        public String[] nameUIList;
        public Color[] colorList;

        private Sprite currentIcon;
        private DialogueManager dialogueManager;

        private Dictionary<String, Sprite> iconDictionary = new Dictionary<String, Sprite>() { };
        private Dictionary<String, String> nameDictionary = new Dictionary<String, String>() { };
        private Dictionary<String, Color> colorDictionary = new Dictionary<String, Color>() { };

        private ManageSoulName nameManager;
        public String currentName;
        private Color currentColor;

        private void Awake()
        {
            nameManager = FindObjectOfType<ManageSoulName>();

            if(nameList.Length == iconList.Length)
            {
                for(int i = 0; i < nameList.Length; i++)
                {
                    iconDictionary.Add(nameList[i], iconList[i]);
                    nameDictionary.Add(nameList[i], nameUIList[i]);
                    colorDictionary.Add(nameList[i], colorList[i]);
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

            currentName = nameDictionary[name];
            currentColor = colorDictionary[name];
            nameManager.ShowName(currentName, currentColor);
        }

        public void ConnectDialogue(DialogueManager d)
        {
            this.dialogueManager = d;
            dialogueManager.iconHandler += RecieveIcon;
        }

        public Sprite GetCurrentIcon()
        {
            return currentIcon;
        }
    }
}
