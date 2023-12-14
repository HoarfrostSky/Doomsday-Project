using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Dialogue
{
    public class ManageSoulName : MonoBehaviour
    {
        private TextMeshProUGUI textUI;

        private void Awake()
        {
            textUI = GetComponent<TextMeshProUGUI>();
        }

        public void ShowName(string newName, Color newColor)
        {
            textUI.text = newName;
            textUI.color = newColor;
        }
    }
}
