using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Interactuables.Interfaces;
using States.Controllers;
using States.ConcreteStates;
using Dialogue;
using Localization;
using Scenes.Controllers;
using Souls;

public class BlameDialogueScript : MonoBehaviour
{
    private Dictionary<int, String[]> blameDialogue = new Dictionary<int, string[]>();
    public TextAsset textAssetData;

    private LocalizationManager localization;
    private GameObject colGO;

    private bool activated = false;

    private void Awake()
    {
        localization = new LocalizationManager();
    }

    private void Start()
    {
        localization.LoadLocalization(FindObjectOfType<SceneStateController>()?.GetLanguage(), textAssetData, blameDialogue);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(activated)
        {
            switch(FindObjectOfType<SoulSpawner>().soulPointer)
            {
                case 2:
                    colGO = collision.gameObject;
                    colGO.GetComponent<PlayerStateController>().SetState(new State_Dialogue(colGO.GetComponent<PlayerStateController>()));
                    FindObjectOfType<DialogueManager>().RecieveMessage(this, blameDialogue[0]);
                    Deactivate();
                    break;
                case 6:
                    colGO = collision.gameObject;
                    colGO.GetComponent<PlayerStateController>().SetState(new State_Dialogue(colGO.GetComponent<PlayerStateController>()));
                    FindObjectOfType<DialogueManager>().RecieveMessage(this, blameDialogue[1]);
                    Deactivate();
                    break;
                case 12:
                    colGO = collision.gameObject;
                    colGO.GetComponent<PlayerStateController>().SetState(new State_Dialogue(colGO.GetComponent<PlayerStateController>()));
                    FindObjectOfType<DialogueManager>().RecieveMessage(this, blameDialogue[2]);
                    Deactivate();
                    break;
            }
        }
    }

    public void Activate()
    {
        activated = true;
    }

    public void Deactivate()
    {
        activated = false;
    }
}