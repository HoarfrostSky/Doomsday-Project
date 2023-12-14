using System.Collections;
using System.Collections.Generic;
using States.Controllers;
using States.ConcreteStates;
using Souls;
using Souls.Interfaces;
using Sword;
using UnityEngine;

namespace Cinematic
{
    public class AlertFinished : MonoBehaviour
    {
        private PlayerStateController playerStateController;

        private void Awake()
        {
            playerStateController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateController>();
        }
        public void FinishCinematicState()
        {
            playerStateController.SetState(new State_Dialogue(playerStateController));
        }

        public void AlertDarkToDestroy()
        {
            switch(GetComponent<ASoul>().GetID())
            {
                case 2:
                    GetComponentInChildren<SaveAnimationManager>().gameObject.transform.localPosition = new Vector3(1f, 0f, 0f);
                    break;
                case 4:
                    GetComponentInChildren<SaveAnimationManager>().gameObject.transform.localPosition = new Vector3(2.1f, 0f, 0f);
                    break;
                case 5:
                    GetComponentInChildren<SaveAnimationManager>().gameObject.transform.localPosition = new Vector3(1.68f, 0f, 0f);
                    break;
                case 8:
                    GetComponentInChildren<SaveAnimationManager>().gameObject.transform.localPosition = new Vector3(1.26f, 0f, 0f);
                    break;
                default:
                    break;
            }
            GameObject.FindGameObjectWithTag("Soul").GetComponentInChildren<SaveAnimationManager>().gameObject.GetComponent<Animator>().SetTrigger("DestroyAction");
            GameObject.Find("Dark1").GetComponent<Animator>().SetTrigger("CastSpell");
        }

        public void NextAttack()
        {
            Debug.Log("Se llama a NextAttack");
            GameObject sword = GameObject.FindGameObjectWithTag("Sword");
            sword.GetComponent<SwordScript>().SetWeight(sword.GetComponent<SwordScript>().GetWeight()*1.5f);

            StartCoroutine(ResetToCondemn());
        }

        IEnumerator ResetToCondemn()
        {
            Debug.Log("Se llama a ResetToCondemn");
            yield return new WaitForSeconds(1f);
            playerStateController.SetState(new State_Condemn(playerStateController));
            yield return null;
        }
    }
}
