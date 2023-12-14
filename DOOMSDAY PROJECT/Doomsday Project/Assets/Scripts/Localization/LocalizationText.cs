using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Scenes.Controllers;

namespace Localization
{
    public class LocalizationText : MonoBehaviour
    {
        [TextArea] public String enText;
        [TextArea] public String esText;

        private TextMeshPro textComponent;
        private TextMeshProUGUI textUIComponent;

        private void Awake()
        {
            textComponent = GetComponent<TextMeshPro>();
            textUIComponent = GetComponent<TextMeshProUGUI>();

            ChangeLanguageText();
        }

        public void ChangeLanguageText()
        {
            switch (FindObjectOfType<SceneStateController>()?.GetLanguage())
            {
                case "english":
                    if (textComponent != null) textComponent.text = enText;
                    else textUIComponent.text = enText;
                    break;
                case "spanish":
                    if (textComponent != null) textComponent.text = esText;
                    else textUIComponent.text = esText;
                    break;
                default:
                    if (textComponent != null) textComponent.text = enText;
                    else textUIComponent.text = enText;
                    break;
            }
        }
    }
}