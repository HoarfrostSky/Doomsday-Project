using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States.Interfaces;
using Souls;
using Music;
using ControlManager = Controls.ControlManager;

namespace States.ConcreteStates
{
    public class State_Save : AConcreteState
    {
        private int limit;
        private float savePoints;
        private GameObject soul;
        private ManageMusic musicManager;

        public State_Save(IPlayerState playerState) : base(playerState)
        {
            this.name = "State_Save";
        }

        public override void Enter()
        {
            Debug.Log("Entering State_Save");

            this.limit = 1000;
            this.savePoints = 0;

            this.soul = GameObject.FindGameObjectWithTag("Soul");

            playerGO.GetComponent<Animator>().SetTrigger("RevertToIdle");
            playerGO.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            playerGO.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, -1f, 0f) * 10);

            musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<ManageMusic>();
            musicManager.JudgeMusicVolume(20f, 0f);
            musicManager.saveMusicSource.volume = 0f;
            musicManager.saveMusicSource.Play();

            controlManager.ResetSpacebar();
        }

        public override void Exit()
        {
            Debug.Log("Exiting State_Save");

        }

        public override void Update()
        {
            controlManager.SaveControls(this, playerState, playerGO);
            Debug.Log("Save points: " + savePoints);
            musicManager.saveMusicSource.volume = savePoints / limit;
            if (savePoints >= limit)
            {
                musicManager.SaveMusicVolume(100f, 0f);
                soul.GetComponentInChildren<SaveAnimationManager>().gameObject.GetComponent<Animator>().SetTrigger("SaveAction");

                GameObject.Find("SpacebarHelp").transform.localScale = new Vector3(0f, 0f, 1f);

                Debug.Log("ALMA SALVADA");
            }
        }

        public void AddSavePoint()
        {
            savePoints += 200 * Time.deltaTime;
        }

        public override void RegisterInteractor(GameObject newInteractor)
        {
        }
    }
}