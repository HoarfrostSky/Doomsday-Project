using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using Souls;
using Souls.Interfaces;

namespace DramaticScreen
{
    public class ManageDramaticScreen : MonoBehaviour
    {
        private SoulSpawner soulSpawner;
        private ASoul soul;

        private void Awake()
        {
            soulSpawner = GameObject.FindGameObjectWithTag("SoulSpawner").GetComponent<SoulSpawner>();

            soulSpawner.dramaticTextHandler += ChangeDramaticText;
            soulSpawner.introTimeHandler += ShowDramaticScreen;

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

            soul.NextMusicOrder();

            StartCoroutine(ManageTime(t));
        }

        public void SetSoul(ASoul soulScript)
        {
            this.soul = soulScript;
        }

        IEnumerator ManageTime(float t)
        {
            yield return new WaitForSeconds(t);

            soul.gameObject.SetActive(true);

            transform.localScale = new Vector3(0f, 0f, 1f);

            yield return null;
        }
    }
}
