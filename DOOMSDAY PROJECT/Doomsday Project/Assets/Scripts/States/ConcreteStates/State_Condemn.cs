using System.Collections;
using System.Collections.Generic;
using Controls;
using UnityEngine;
using Sword;
using Player;
using States.Interfaces;

namespace States.ConcreteStates
{
    public class State_Condemn : AConcreteState
    {

        public float mouseDeltaHPosition;
        public float angleCondemn = 0;

        private GameObject sword;
        private SwordScript swordScript;
        private GameObject soul;
        private GameObject dark1;
        private float previousHPos = 0;

        public State_Condemn(IPlayerState playerState) : base(playerState)
        {
            this.name = "State_Condemn";
        }

        public override void Enter()
        {
            Debug.Log("Entering State_Condemn");

            playerGO.GetComponent<Animator>().SetTrigger("AttackIdle");
            playerGO.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            playerGO.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, -1f, 0f) * 10);

            this.sword = GameObject.FindGameObjectWithTag("Sword");
            sword.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            this.swordScript = sword.GetComponent<SwordScript>();

            this.soul = GameObject.FindGameObjectWithTag("Soul");
            if(playerGO.GetComponent<AttackSoulManager>().GetCurrentAttack() == 0) soul.GetComponent<Animator>().SetTrigger("SoulTerrorTransition");

            this.dark1 = GameObject.Find("Dark1");
            sword.transform.localPosition = new Vector3(-3.3f, 0f, 0f);
            sword.transform.localScale = new Vector3(1f, 1f, 1f);

            controlManager.ResetSpacebar();
            controlManager.canAttack = true;
        }

        public override void Exit()
        {
            Debug.Log("Exiting State_Condemn");

            
            GameObject.Find("SpacebarHelp").transform.localScale = new Vector3(0f, 0f, 1f);
            GameObject.FindGameObjectWithTag("Sword").transform.localScale = new Vector3(0f, 0f, 1f);

            if (playerGO.GetComponent<AttackSoulManager>().GetCurrentAttack() == playerGO.GetComponent<AttackSoulManager>().GetMaxAttacks())
            {
                playerGO.GetComponent<AttackSoulManager>().ResetCurrentAttack();
                MonoBehaviour.Destroy(soul);
            }
        }

        public override void Update()
        {
            float mouseHPos = Input.mousePosition.x;
            mouseDeltaHPosition = mouseHPos - previousHPos;
            previousHPos = mouseHPos;

            if(sword.transform.localEulerAngles.z < 100f || sword.transform.localEulerAngles.z >= 290f) sword.transform.RotateAround(playerGO.transform.position, Vector3.forward, 0.01f * swordScript.weight);

            controlManager.CondemnControls(this, playerState, mouseDeltaHPosition, sword, playerGO);
        }
    }
}