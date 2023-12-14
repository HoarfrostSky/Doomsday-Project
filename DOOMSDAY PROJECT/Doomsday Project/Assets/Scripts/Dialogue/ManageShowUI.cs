using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class ManageShowUI : MonoBehaviour
    {
        public GameObject iconGO;
        public GameObject textGO;
        public GameObject nameGO;
        public GameObject empathiseTextGO;

        public Vector3 iconSize;
        public Vector3 textSize;
        public Vector3 nameSize;
        public Vector3 empathiseTextSize;

        public void ShowDialogueUI()
        {
            iconGO.GetComponent<RectTransform>().localScale = iconSize;
            textGO.GetComponent<RectTransform>().localScale = textSize;
            nameGO.GetComponent<RectTransform>().localScale = nameSize;
        }

        public void HideDialogueUI()
        {
            iconGO.GetComponent<RectTransform>().localScale = new Vector3(0f, 0f, 0f);
            textGO.GetComponent<RectTransform>().localScale = new Vector3(0f, 0f, 0f);
            nameGO.GetComponent<RectTransform>().localScale = new Vector3(0f, 0f, 0f);
            empathiseTextGO.GetComponent<RectTransform>().localScale = new Vector3(0f, 0f, 0f);
        }

        public void ShowEmpathiseText()
        {
            empathiseTextGO.GetComponent<RectTransform>().localScale = empathiseTextSize;
        }
    }
}
