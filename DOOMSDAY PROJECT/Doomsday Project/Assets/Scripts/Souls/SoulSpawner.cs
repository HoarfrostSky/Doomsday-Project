using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Souls.Interfaces;
using Cinematic;
using DramaticScreen;
using Localization;
using Scenes.Controllers;

namespace Souls
{
    public class SoulSpawner : MonoBehaviour
    {
        public int[] soulOrderList;
        public GameObject[] soulPrefabList;
        public GameObject soulContainerParent;
        public float introTime;

        public int maxRandomAnimations;

        public int soulPointer = 0;
        private GameObject currentSoul;
        private Dictionary<int, GameObject> soulDictionary = new Dictionary<int, GameObject>() { };

        public TextAsset textAssetData;
        private LocalizationManager localizationManager;

        public int nRandomDialogues;
        private int chosenDialogue = 0;
        private Dictionary<int, String[]> randomDialogueDictionary = new Dictionary<int, String[]>() { };

        public EventHandler<GameObject> sendSoulHandler;
        public EventHandler<String> dramaticTextHandler;
        public EventHandler<float> introTimeHandler;

        private List<int> previousSouls = new List<int>();

        private void Awake()
        {
            localizationManager = new LocalizationManager();
            localizationManager.LoadLocalization(FindObjectOfType<SceneStateController>()?.GetLanguage(), textAssetData, randomDialogueDictionary);

            for(int i = 0; i < soulPrefabList.Length; i++)
            {
                soulDictionary.Add(i, soulPrefabList[i]);
            }
        }

        public void SpawnSoul()
        {
            StartCoroutine(GenerateSoulGO(introTime));
        }

        private void ChooseRandomSoul()
        {
            currentSoul.GetComponent<ASoul>().dialogue = GenerateRandomDialogue();
        }

        private String[] GenerateRandomDialogue()
        {
            int random = 0;
            do
            {
                random = (int)UnityEngine.Random.Range(1, nRandomDialogues);
            } while (previousSouls.Contains(random));

            previousSouls.Add(random);

            chosenDialogue = random;
            previousSouls.Add(random);

            while (random > maxRandomAnimations)
            {
                random -= maxRandomAnimations;
            }

            Animator soulAnim = currentSoul.GetComponent<Animator>();

            for (int i = 0; i < maxRandomAnimations; i++)
            {
                soulAnim.SetLayerWeight(i, 0);
            }

            soulAnim.SetLayerWeight(random, 1);
            soulAnim.SetInteger("SoulNumber", random);

            return randomDialogueDictionary[chosenDialogue];
        }

        IEnumerator GenerateSoulGO(float time)
        {
            Debug.Log("Alma numero " + soulPointer + ", de tipo " + soulOrderList[soulPointer]);
            GameObject currentSoulGO = soulDictionary[soulOrderList[soulPointer]];
            currentSoulGO.SetActive(false);
            currentSoul = Instantiate(currentSoulGO, soulContainerParent.transform);

            Debug.Log(currentSoul.GetComponent<ASoul>());

            GameObject.FindGameObjectWithTag("DramaticScreen").GetComponent<ManageDramaticScreen>().SetSoul(currentSoul.GetComponent<ASoul>());
            introTimeHandler?.Invoke(this, introTime);

            yield return new WaitForSeconds(time);

            currentSoulGO.SetActive(true);

            yield return null;

            sendSoulHandler?.Invoke(this, currentSoul);

            if (soulOrderList[soulPointer] == 0)
            {
                ChooseRandomSoul();
            }

            soulPointer++;
            yield return null;
        }
    }
}
