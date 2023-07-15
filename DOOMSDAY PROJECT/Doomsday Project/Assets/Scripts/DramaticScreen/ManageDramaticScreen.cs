using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

namespace DramaticScreen
{
    public class ManageDramaticScreen : MonoBehaviour
    {
        private void Awake()
        {
            //---
            //Suscribir al objeto en cuestión en texto (primero) y duración (segundo)
            //---
        }
        public void ChangeDramaticText(object sender, String dramText)
        {
            GetComponentInChildren<TextMeshProUGUI>().text = dramText;
        }
        public void ShowDramaticScreen(object sender, float t)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);

            //---
            //Efectos
            //---

            StartCoroutine(ManageTime(t));
        }

        IEnumerator ManageTime(float t)
        {
            yield return new WaitForSeconds(t);
            transform.localScale = new Vector3(0f, 0f, 1f);
            yield return null;
        }
    }
}
