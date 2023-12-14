using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scenes.Controllers;
using MainMenu;

namespace Localization
{
    public class SelectLanguage : MonoBehaviour
    {
        public string language;
        public GameObject awakeGO;

        public void SetLanguage()
        {
            FindObjectOfType<SceneStateController>().SetLanguage(language);
            awakeGO.GetComponent<LocalizationText>().ChangeLanguageText();
            FindObjectOfType<ManageIntro>().LoadLanguage();
        }
    }
}