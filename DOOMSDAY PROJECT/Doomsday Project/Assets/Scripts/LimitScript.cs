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

public class LimitScript : MonoBehaviour
{
    private Dictionary<int, String[]> limitDialogue = new Dictionary<int, string[]>();
    public TextAsset textAssetData;

    private LocalizationManager localization;
    private GameObject colGO;

    private void Awake()
    {
        localization = new LocalizationManager();
    }

    private void Start()
    {
        localization.LoadLocalization(FindObjectOfType<SceneStateController>()?.GetLanguage(), textAssetData, limitDialogue);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        colGO = collision.gameObject;
        colGO.GetComponent<PlayerStateController>().SetState(new State_Dialogue(colGO.GetComponent<PlayerStateController>()));
        FindObjectOfType<DialogueManager>().RecieveMessage(this, limitDialogue[0]);
    }
}
