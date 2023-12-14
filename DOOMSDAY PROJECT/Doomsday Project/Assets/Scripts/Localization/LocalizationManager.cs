using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Scenes.Controllers;

namespace Localization
{
    public class LocalizationManager
    {
        public LocalizationManager() { }

        public void LoadLocalization(String language, TextAsset textData, Dictionary<int, String[]> dict)
        {
            String[] data = textData.text.Split(";");

            switch (language)
            {
                case "english":
                    for (int i = 0; i < data.Length; i = i + 3)
                    {
                        Debug.Log("data length: " + data.Length + "; i: " + i);
                        dict.Add(i / 3, data[i + 1].Split("//"));
                    }
                    break;
                case "spanish":
                    for (int i = 0; i < data.Length; i = i + 3)
                    {
                        Debug.Log("data length: " + data.Length + "; i: " + i);
                        dict.Add(i / 3, data[i + 2].Split("//"));
                    }
                    break;
                default:
                    for (int i = 0; i < data.Length; i = i + 3)
                    {
                        Debug.Log("data length: " + data.Length + "; i: " + i);
                        dict.Add(i / 3, data[i + 1].Split("//"));
                    }
                    break;
            }
        }
        public void LoadLocalizationString(String language, TextAsset textData, Dictionary<int, String> dict)
        {
            String[] data = textData.text.Split(";");

            switch (language)
            {
                case "english":
                    for (int i = 0; i < data.Length; i = i + 3)
                    {
                        Debug.Log("data length: " + data.Length + "; i: " + i);
                        dict.Add(i / 3, data[i + 1]);
                    }
                    break;
                case "spanish":
                    for (int i = 0; i < data.Length; i = i + 3)
                    {
                        Debug.Log("data length: " + data.Length + "; i: " + i);
                        dict.Add(i / 3, data[i + 2]);
                    }
                    break;
                default:
                    for (int i = 0; i < data.Length; i = i + 3)
                    {
                        Debug.Log("data length: " + data.Length + "; i: " + i);
                        dict.Add(i / 3, data[i + 1]);
                    }
                    break;
            }
        }

        public void ResetLanguageDictionaries(Dictionary<int, String> dict)
        {
            dict.Clear();
        }
    }
}
