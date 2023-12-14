using System.Collections;
using System.Collections.Generic;
using System;
using Dialogue;
using UnityEngine;
using States.Controllers;
using States.ConcreteStates;
using Music;
using Localization;
using Scenes.Controllers;

namespace Souls.Interfaces
{
    public abstract class ASoul : MonoBehaviour, ISoul
    {
        public int id;
        public int maxAtaques;
        public TextAsset dialogueData;
        public Dictionary<int, String> dialogueDict = new Dictionary<int, string>();
        [TextArea(3, 10)] public String[] dialogue;
        public float moveSpeed;
        public String[] musicLayerOrders;
        public GameObject blameTrinket;

        private int musicOrder = -1;
        protected bool interactuable = false;
        protected GameObject playerGO;
        protected ManageMusic musicManager;

        private LocalizationManager localizationManager;

        public EventHandler<String[]> sendDialogueHandler;

        public AudioClip[] audioClips;

        private void Awake()
        {
            playerGO = GameObject.FindGameObjectWithTag("Player");
            playerGO.GetComponent<DialogueManager>().ConnectSoul(this);

            localizationManager = new LocalizationManager();
            localizationManager.LoadLocalizationString(FindObjectOfType<SceneStateController>()?.GetLanguage(), dialogueData, dialogueDict);

            for (int i = 0; i < dialogueDict.Count; i++)
            {
                dialogue[i] = dialogueDict[i];
            }
        }

        private void Start()
        {

            switch (GetID())
            {
                case 1: //Harn
                    MoveToLocalPosition(new Vector3(15f, 0f, 0f));
                    break;
                case 2: //Child
                    MoveToLocalPosition(new Vector3(15f, 0f, 0f));
                    break;
                case 3: //Nur
                    MoveToLocalPosition(new Vector3(15f, 0f, 0f));
                    break;
                case 4: //Bretta
                    MoveToLocalPosition(new Vector3(14f, 0f, 0f));
                    break;
                case 5: //Hayure
                    MoveToLocalPosition(new Vector3(14f, 0f, 0f));
                    break;
                case 6: //Colin
                    MoveToLocalPosition(new Vector3(15f, 0f, 0f));
                    break;
                case 7: //Nur's father
                    MoveToLocalPosition(new Vector3(15f, 0f, 0f));
                    break;
                case 8: //Bretta
                    MoveToLocalPosition(new Vector3(14.5f, 0f, 0f));
                    break;
                default: //random
                    MoveToLocalPosition(new Vector3(15f, 0f, 0f));
                    break;
            }
        }

        public void NextMusicOrder()
        {
            Debug.Log("Se ha llamado a next music order");

            musicOrder++;
            String[] processedOrder = musicLayerOrders[musicOrder].Split("_");

            if(musicManager == null)
            {
                musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<ManageMusic>();
                musicManager.StartMusic(id);
            }

            if(processedOrder.Length == 4) musicManager.ManageVolumeLayer(int.Parse(processedOrder[0]), float.Parse(processedOrder[1]), float.Parse(processedOrder[2]), float.Parse(processedOrder[3]));
        }

        public void NextMusicOrders(int n)
        {
            for(int i = 0; i < n; i++)
            {
                NextMusicOrder();
            }
        }

        public int GetID()
        {
            return id;
        }

        public bool GetInteractuable()
        {
            return interactuable;
        }

        public void SendDialogue()
        {
            playerGO.GetComponent<PlayerStateController>().SetState(new State_Dialogue(playerGO.GetComponent<PlayerStateController>()));
            sendDialogueHandler?.Invoke(this, dialogue);
        }

        public void MoveToLocalPosition(Vector3 d)
        {
            StartCoroutine(MoveSoul(d));
        }

        IEnumerator MoveSoul(Vector3 destination)
        {
            float elapsed = 0;
            Vector3 startingPoint = transform.localPosition;
            while(this.transform.localPosition != destination)
            {
                this.transform.localPosition = Vector3.Lerp(startingPoint, destination, elapsed);
                elapsed += (0.01f * moveSpeed * Time.deltaTime);
                yield return null;
            }

            GetComponent<Animator>().SetTrigger("SoulTransition");
            yield return null;
        }

        private void OnDestroy()
        {
            GameObject trinketContainer = GameObject.FindGameObjectWithTag("TrinketContainer");
            Instantiate(blameTrinket, trinketContainer.transform);
        }

        public void PlayTransitionSound()
        {
            GetComponent<AudioSource>().clip = audioClips[0];
            GetComponent<AudioSource>().volume = 0.6f;
            GetComponent<AudioSource>().Play();
        }

        public void PlayFallSound()
        {
            GetComponent<AudioSource>().clip = audioClips[1];
            GetComponent<AudioSource>().volume = 1.0f;
            GetComponent<AudioSource>().Play();
        }

        public void PlayMovement1Sound()
        {
            GetComponent<AudioSource>().clip = audioClips[2];
            GetComponent<AudioSource>().volume = 0.05f;
            GetComponent<AudioSource>().Play();
        }

        public void PlayMovement2Sound()
        {
            GetComponent<AudioSource>().clip = audioClips[3];
            GetComponent<AudioSource>().volume = 0.05f;
            GetComponent<AudioSource>().Play();
        }

        public void PlayMovement3Sound()
        {
            GetComponent<AudioSource>().clip = audioClips[4];
            GetComponent<AudioSource>().volume = 0.05f;
            GetComponent<AudioSource>().Play();
        }
    }
}
